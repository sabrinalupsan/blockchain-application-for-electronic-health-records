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
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;

namespace BlockchainApp
{
    public partial class DoctorLogIn : Form
    {
        private Doctor doc;
        int successfulAuthentication = 0;

        public DoctorLogIn()
        {
            InitializeComponent();
        }

        private int generatePIN()
        {
            Random random = new Random();
            return random.Next(999, 10000);
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

        private void tbDocID_Validating(object sender, CancelEventArgs e)
        {
            if (tbDocID.Text.Trim().Length != 7)
            {
                errorProvider.SetError(tbDocID, "Wrong ID.");
                e.Cancel = true;
            }
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

        private void tbDocID_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbDocID, null);
        }

        private void updateLastLogin(long doctorID)
        {
            var builder = build();
            var lastLoginQuery = "UPDATE Doctors" + " SET last_login = SYSDATETIME()" + "WHERE doctor_id =" + doctorID + ";";
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

        private string updatePIN(long doctorID)
        {
            int newPIN = generatePIN();
            MessageBox.Show("Your new token PIN for the next 30 days is: " + newPIN.ToString());
            string hashedNewPIN = computeHash2(newPIN.ToString());
            var builder = build();
            var updatePINquery = "UPDATE Doctors SET hashed_PIN = @hashPIN WHERE doctor_id = " + doctorID + ";";
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

        private void startDoctorInterface(long dbID, byte[] hashedPassword, string specialisation, string lastName, string firstName, byte[] dbPIN, DateTime date)
        {
            Doctor doc = new Doctor(dbID, hashedPassword, specialisation, lastName, firstName, dbPIN, DateTime.Now);
            DoctorInterface doctorInterface = new DoctorInterface(doc);
            Hide();
            doctorInterface.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (successfulAuthentication < 3 && ValidateChildren()==true)
            {
                long docID = long.Parse(tbDocID.Text.Trim());

                byte[] hashedPassword = computeHash(tbPassword.Text.Trim().ToString());
                byte[] hashedPIN = computeHash(tbPIN.Text.Trim().ToString());

                SqlConnectionStringBuilder builder = build();

                var querry = "SELECT * from Doctors;";

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    bool connected = false;
                    conn.Open();
                    var command = new SqlCommand(querry, conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long dbID = (int)reader["doctor_id"];
                            string dbPassword = (string)reader["hashed_pass"];
                            string hashedNewPIN = null;
                            if (dbID.CompareTo(docID) == 0 && (Encoding.Default.GetString(hashedPassword)).CompareTo(dbPassword) == 0)
                            {
                                connected = true;
                                string lastName = (string)reader["doctor_last_name"];
                                string firstName = (string)reader["doctor_first_name"];
                                string specialisation = (string)reader["specialization"];

                                if (reader["hashed_PIN"] == System.DBNull.Value)
                                {
                                    hashedNewPIN = updatePIN(dbID);
                                    updateLastLogin(dbID);
                                    startDoctorInterface(dbID, hashedPassword, specialisation, lastName, firstName, 
                                        System.Text.Encoding.UTF8.GetBytes(hashedNewPIN), DateTime.Now);
                                }
                                else
                                {
                                    string dbPIN = (string)reader["hashed_PIN"];
                                    if ((Encoding.Default.GetString(hashedPIN)).CompareTo(dbPIN) == 0)
                                    {
                                        DateTime theDate = (DateTime)reader["last_login"];
                                        if ((DateTime.Today.Date - theDate.Date).Days > 30)
                                        {
                                            hashedNewPIN = updatePIN(docID);
                                            startDoctorInterface(dbID, hashedPassword, specialisation, lastName, firstName,
                                        System.Text.Encoding.UTF8.GetBytes(hashedNewPIN), DateTime.Now);
                                        }
                                        else
                                            startDoctorInterface(dbID, hashedPassword, specialisation, lastName, firstName, hashedPIN, DateTime.Now);
                                        updateLastLogin(dbID);

                                    }
                                    else connected = false;
                                }

                            }
                        }
                    }
                    if (connected == false)
                        MessageBox.Show("Invalid credentials!");
                }
                successfulAuthentication++;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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

        private void tbPassword_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbPassword, null);
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
    }
}
