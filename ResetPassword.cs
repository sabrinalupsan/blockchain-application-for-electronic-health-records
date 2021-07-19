using Microsoft.Data.SqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainApp
{
    public partial class ResetPassword : MaterialSkin.Controls.MaterialForm
    {
        private SqlConnectionStringBuilder builder;
        private Email email;
        private string verificationCode;
        private static int PASSWORD_LENGTH = 9;
        private static int ID_LENGTH = 13;

        public ResetPassword()
        {
            InitializeComponent();
            MySqlBuilder mySqlBuilder = MySqlBuilder.instance;
            builder = mySqlBuilder.builder;
            email = Email.instance;
            verificationCode = generateVerificationCode();
            prepareForm();
        }

        private void prepareForm()
        {
            panel2.Visible = false;
            panel3.Visible = false;
            progressBar.Value = 0;
            statusLabel.Text = "";
        }

        private string computeHash(string toHash)
        {
            var hasher = SHA256.Create();
            byte[] byteHash = System.Text.Encoding.UTF8.GetBytes(toHash);
            byte[] finalHash = hasher.ComputeHash(byteHash);
            return Encoding.Default.GetString(finalHash);
        }

        private string saltPassword(string password, long ID)
        {
            string saltedPassword = null;
            for (int i = 0; i < password.Length; i++)
            {
                if (i == 2)
                    saltedPassword += ID.ToString();
                saltedPassword += password[i];
            }
            return saltedPassword;
        }

        private bool checkInitialData()
        {
            try
            {
                long person_id = long.Parse(tbID.Text.Trim().ToString());
                string personID = tbID.Text.Trim().ToString();

                string stringPin = tbPIN.Text.Trim().ToString();
                int PIN = int.Parse(stringPin);

                if (personID.Length != ID_LENGTH || (personID.All(char.IsNumber) == false))
                {
                    MessageBox.Show("The ID is invalid.");
                    return false;
                }
                if (stringPin.Length != 4 || (stringPin.All(char.IsNumber) == false))
                {
                    MessageBox.Show("The ID is invalid.");
                    return false;
                }
                try
                {
                    var selectDoctorPin = "SELECT hashed_PIN, email FROM Doctors WHERE doctor_id = " + person_id; //check for SQL injection
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        var command = new SqlCommand(selectDoctorPin, connection);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows == true)
                            {
                                string hashedPIN = computeHash(PIN.ToString());
                                string dbPIN = (string)reader["hashed_PIN"];
                                if (hashedPIN.CompareTo(dbPIN) != 0)
                                    return false;
                                string destinationEmail = tbEmail.Text.Trim().ToString();
                                string databaseEmail = (string)reader["email"];
                                if (destinationEmail.CompareTo(databaseEmail) != 0)
                                    return false;
                                return true;
                            }
                        }
                    }

                    var selectPatientPIN = "SELECT hashed_PIN, email FROM Patients WHERE patient_id = " + person_id; //check for SQL injection
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        var command = new SqlCommand(selectPatientPIN, connection);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows == true)
                            {
                                string hashedPIN = computeHash(PIN.ToString());
                                string dbPIN = (string)reader["hashed_PIN"];
                                if (hashedPIN.CompareTo(dbPIN) != 0)
                                    return false;
                                string destinationEmail = tbEmail.Text.Trim().ToString();
                                string databaseEmail = (string)reader["email"];
                                if (destinationEmail.CompareTo(databaseEmail) != 0)
                                    return false;
                                return true;
                            }
                        }
                    }
                }
                catch (System.InvalidCastException)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        private bool checkData()
        {
            
            if (tbPassword.Text.Trim().Length < PASSWORD_LENGTH || !(tbPassword.Text.Trim().Any(char.IsUpper)) || !(tbPassword.Text.Trim().Any(char.IsLower))
                || !(tbPassword.Text.Trim().Any(char.IsLetter)) || !(tbPassword.Text.Trim().Any(char.IsNumber)) ||
                    !(tbPassword.Text.Trim().Any(char.IsPunctuation)))
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Your password needs to include a number, a lowercase character, an uppercase character, a special symbol and " +
                    "at least 9 characters!");
                return false;
            }
            if (tbPassword.Text.Trim().CompareTo(tbRePassword.Text.Trim()) != 0)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("The passwords don't match!");
                return false;
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (checkData()==true)
            {
                long ID = long.Parse(tbID.Text.Trim().ToString());
                int PIN = int.Parse(tbPIN.Text.Trim().ToString());
                string saltedPassword = saltPassword(tbPassword.Text.Trim().ToString(), ID);
                string hashedPassword = computeHash(saltedPassword);
                string hashedPIN = computeHash(PIN.ToString());
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {

                    var querryDoctors =
                        "UPDATE Doctors SET hashed_pass = @hashedpassword WHERE doctor_id = @doctor_id;";
                    var querryPatients =
                        "UPDATE Patients SET hashed_pass = @hashedpassword WHERE patient_id = @patient_id;";
                    using (SqlCommand doctorsCommand = new SqlCommand(querryDoctors, conn))
                    {
                        conn.Open();
                        doctorsCommand.Parameters.AddWithValue("@hashedpassword", hashedPassword);
                        doctorsCommand.Parameters.AddWithValue("@doctor_id", ID);

                        using (SqlDataReader reader = doctorsCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                    using (SqlCommand patientsCommand = new SqlCommand(querryPatients, conn))
                    {
                        patientsCommand.Parameters.AddWithValue("@hashedpassword", hashedPassword);
                        patientsCommand.Parameters.AddWithValue("@patient_id", ID);

                        using (SqlDataReader reader = patientsCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Info("The user with the ID {0} just changed their password.", ID);
                progressBar.Value = 100;
                statusLabel.Text = "The password was reset.";
                DialogResult = DialogResult.None;
            }
        }

        private bool checkVerificationCode()
        {
            if (tbVerificationCode.Text.Trim().ToString().CompareTo(verificationCode) == 0)
                return true;
            return false;
        }

        private string generateVerificationCode()
        {
            Random r = new Random();
            int randNum = r.Next(1000000);
            string sixDigitNumber = randNum.ToString("D6");
            return sixDigitNumber;
        }

        private void btnSendVerificationCode_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            string id = tbID.Text.Trim().ToString();
            string PIN = tbPIN.Text.Trim().ToString();
            string destinationEmail = tbEmail.Text.Trim().ToString();
            try
            {
                if (checkInitialData() == true)
                {
                    email.Send(destinationEmail, "Password renewal verification code", "Your verification code is: " + verificationCode);
                    MessageBox.Show("An email has been sent! Make sure to check in spam too.");
                    panel3.Visible = true;
                }
                else
                    MessageBox.Show("Incorrect credentials");
            }
            catch (System.FormatException ex)
            {
                if (ex.Message.CompareTo("The specified string is not in the form required for an e-mail address.") == 0)
                    MessageBox.Show("Wrong email specified.");
                if(ex.Message.CompareTo("Input string was not in a correct format.")==0)
                    MessageBox.Show("Incorrect credentials.");

            }

        }

        private void btnCheckVerificationCode_Click(object sender, EventArgs e)
        {
            if (checkVerificationCode() == true)
            {
                DialogResult = DialogResult.None;
                panel1.Visible = false;
                panel3.Visible = false;
                panel2.Visible = true;
            }
            else
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Wrong code!");
            }
        }

    }
}
