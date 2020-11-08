using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using NLog;

namespace BlockchainApp
{
    public partial class PacientLogIn : Form
    {
        private int successfulAuthentication = 0;

        public PacientLogIn()
        {
            InitializeComponent();
            successfulAuthentication = 0;
        }

        private byte[] computeHash(string toHash)
        {
            //https://stackoverflow.com/questions/3984138/hash-string-in-c-sharp
            var hasher = SHA256.Create();
            byte[] byteHash = System.Text.Encoding.UTF8.GetBytes(toHash);
            return hasher.ComputeHash(byteHash);
        }

        private string computeHash2(string toHash)
        {
            var hasher = SHA256.Create();
            byte[] byteHash = System.Text.Encoding.UTF8.GetBytes(toHash);
            byte[] finalHash = hasher.ComputeHash(byteHash);
            return Encoding.Default.GetString(finalHash);
        }

        private SqlConnectionStringBuilder build()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "blockchainapp.database.windows.net";
            builder.UserID = "lupsansabrina18";
            builder.Password = "Selenacolierul9!";
            builder.InitialCatalog = "blockchainapp";
            return builder;
        }

        private int generatePIN()
        {
            Random random = new Random();
            return random.Next(999, 10000);
        }

        private void updateLastLogin(long patientID)
        {
            var builder = build();
            var lastLoginQuery = "UPDATE Pacients" + " SET last_login = SYSDATETIME()" + "WHERE pacient_id =" + patientID + ";";
            using (SqlConnection lastLoginConnection = new SqlConnection(builder.ConnectionString))
            {
                lastLoginConnection.Open();
                using (SqlCommand lastLoginCommand = new SqlCommand(lastLoginQuery, lastLoginConnection))
                {
                    lastLoginCommand.Parameters.AddWithValue("@last_login", DateTime.Now.ToString("yyyy-MM-dd"));

                    using (SqlDataReader lastLoginreader = lastLoginCommand.ExecuteReader())
                        while (lastLoginreader.Read())
                            Console.WriteLine("{0} {1}", lastLoginreader.GetString(0), lastLoginreader.GetString(1));
                }
            }
        }

        private string updatePIN(long patientID)
        {
            int newPIN = generatePIN();
            MessageBox.Show("Your new token PIN for the next 30 days is: " + newPIN.ToString());
            string hashedNewPIN = computeHash2(newPIN.ToString());
            var builder = build();
            var updatePINquery = "UPDATE Pacients SET hashed_PIN = @hashPIN WHERE pacient_id = " + patientID + ";";
            using (SqlConnection updatePINconnection = new SqlConnection(builder.ConnectionString))
            {
                updatePINconnection.Open();
                using (SqlCommand updatePINCommand = new SqlCommand(updatePINquery, updatePINconnection))
                {
                    updatePINCommand.Parameters.AddWithValue("@hashPIN", hashedNewPIN);

                    using (SqlDataReader updatePINReader = updatePINCommand.ExecuteReader())
                        while (updatePINReader.Read())
                            Console.WriteLine("{0} {1}", updatePINReader.GetString(0), updatePINReader.GetString(1));
                }
            }
            return hashedNewPIN;
        }

        private void startPatientInterface(long patientID, byte[] hashedPassword, byte[] hashedPIN, string lastName, string firstName, DateTime birthday)
        {
            Patient patient = new Patient(patientID, hashedPassword, hashedPIN, lastName, firstName, birthday);
            PatientInterface patientInterface = new PatientInterface(patient);
            Hide();
            patientInterface.ShowDialog();
        }

        private bool validatePatient()
        {
            if (tbPacientID.Text.Trim().Length != 7 || (tbPacientID.Text.Trim().All(char.IsNumber) == false))
            {
                MessageBox.Show("The ID is invalid.");
                return false;
            }
            if (tbPassword.Text.Trim().Length < 5 || !(tbPassword.Text.Trim().Any(char.IsUpper)) || !(tbPassword.Text.Trim().Any(char.IsLower))
                || !(tbPassword.Text.Trim().Any(char.IsLetter)) || !(tbPassword.Text.Trim().Any(char.IsNumber)) ||
                    !(tbPassword.Text.Trim().Any(char.IsPunctuation)))
            {
                MessageBox.Show("Your password needs to include a number, a lowercase character, an uppercase character, a special symbol and " +
                    "at least 5 characters!");
                return false;
            }
            return true;
        }

        private bool validatePIN()
        {
            if (tbPIN.Text.Trim().ToString().Length != 4 || (tbPIN.Text.Trim().All(char.IsNumber) == false))
                return false;
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            long inputedPacientID = -1;
            try
            {
                if (successfulAuthentication < 4 && validatePatient() == true)
                {
                    inputedPacientID = long.Parse(tbPacientID.Text.Trim());

                    string inputedPass = tbPassword.Text.Trim().ToString();
                    string hashedPass = computeHash2(inputedPass);

                    SqlConnectionStringBuilder builder = build();

                    var querry = "SELECT * from Pacients;";

                    using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                    {
                        conn.Open();
                        var command = new SqlCommand(querry, conn);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int DBID = (int)reader["pacient_id"];
                                long databaseID = DBID;
                                string databasePassword = (string)reader["hashed_pass"];

                                if (inputedPacientID.CompareTo(databaseID) == 0 && hashedPass.CompareTo(databasePassword) == 0)
                                    if (reader["hashed_PIN"] == System.DBNull.Value)
                                    {
                                        string hashedNewPIN = updatePIN(inputedPacientID);

                                        string lastName = (string)reader["pacient_last_name"];
                                        string firstName = (string)reader["pacient_first_name"];
                                        DateTime theDate = (DateTime)reader["last_login"];
                                        DateTime birthday = (DateTime)reader["birthday"];

                                        byte[] thePass = System.Text.Encoding.UTF8.GetBytes(hashedPass);
                                        byte[] thePIN = System.Text.Encoding.UTF8.GetBytes(hashedNewPIN);

                                        logger.Debug("The patient with ID {0} logged in.", inputedPacientID);
                                        startPatientInterface(inputedPacientID, thePass, thePIN, lastName, firstName, birthday);
                                    }
                                    else
                                    {
                                        try
                                        {
                                            if (validatePIN() == true)
                                            {
                                                int inputedPIN = int.Parse(tbPIN.Text.Trim().ToString());
                                                string hashedPIN = computeHash2(inputedPIN.ToString());

                                                string databasePIN = (string)reader["hashed_PIN"];
                                                if (hashedPIN.CompareTo(databasePIN) == 0)
                                                {
                                                    string lastName = (string)reader["pacient_last_name"];
                                                    string firstName = (string)reader["pacient_first_name"];
                                                    DateTime theDate = (DateTime)reader["last_login"];
                                                    DateTime birthday = (DateTime)reader["birthday"];

                                                    if ((DateTime.Today.Date - theDate.Date).Days > 30)
                                                    {
                                                        string hashedNewPIN = updatePIN(inputedPacientID);
                                                    }

                                                    updateLastLogin(inputedPacientID);

                                                    byte[] thePass = System.Text.Encoding.UTF8.GetBytes(hashedPass);
                                                    byte[] thePIN = System.Text.Encoding.UTF8.GetBytes(hashedPIN);

                                                    logger.Debug("The doctor with ID {0} logged in.", inputedPacientID);
                                                    startPatientInterface(inputedPacientID, thePass, thePIN, lastName, firstName, birthday);
                                                }
                                                else
                                                {
                                                    successfulAuthentication++;
                                                    MessageBox.Show("Incorrect PIN!");
                                                }
                                            }
                                            else
                                            {
                                                successfulAuthentication++;
                                                MessageBox.Show("Incorrect PIN!");
                                            }
                                        }
                                        catch (FormatException)
                                        {
                                            successfulAuthentication++;
                                            MessageBox.Show("Incorrect PIN!");
                                        }
                                    }
                            }
                        }
                        successfulAuthentication++;
                    }
                }
                else
                {
                    successfulAuthentication++;
                    if (successfulAuthentication > 4)
                    {
                        logger.Warn("The patient with ID {0} is repeatedly trying to log in.", inputedPacientID);
                        MessageBox.Show("Too many attempts!");
                    }
                }
            }
            catch (FormatException)
            {
                successfulAuthentication++;
                if (successfulAuthentication > 4)
                {
                    logger.Warn("The patient with ID {0} is repeatedly trying to log in.", inputedPacientID);
                    MessageBox.Show("Too many attempts!");
                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbPacientID_Validating(object sender, CancelEventArgs e)
        {
            if (tbPacientID.Text.Trim().Length != 7)
            {
                errorProvider.SetError(tbPacientID, "Wrong ID.");
                e.Cancel = true;
            }
        }

        private void tbPacientID_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbPacientID, null);
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text.Trim().Length < 5 || !(tbPassword.Text.Trim().Any(char.IsUpper)) || !(tbPassword.Text.Trim().Any(char.IsLower))
                || !(tbPassword.Text.Trim().Any(char.IsLetter)) || !(tbPassword.Text.Trim().Any(char.IsNumber)) ||
                !(tbPassword.Text.Trim().Any(char.IsPunctuation)))
            {
                errorProvider.SetError(tbPassword, "Your passwords need to include a number, an uppercase character, a special symbol and " +
                    "at least 5 characters!");
                e.Cancel = true;
            }
        }

        private void tbPassword_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbPassword, null);
        }

        private void tbPIN_Validating(object sender, CancelEventArgs e)
        {
            //if (!(tbPIN.Text.Trim().All(char.IsNumber)) || tbPIN.Text.Trim().Length != 4)
            //{
            //    errorProvider.SetError(tbPIN, "You did not input a PIN code!");
            //    e.Cancel = true;
            //}
        }

        private void tbPIN_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbPIN, null);
        }
    }
}
