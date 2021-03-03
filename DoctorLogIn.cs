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
using NLog;
using System.Net;
using NLog.Targets;
using Microsoft.Data.SqlClient;
using MaterialSkin;

namespace BlockchainApp
{
    public partial class DoctorLogIn : MaterialSkin.Controls.MaterialForm
    {
        private int successfulAuthentication = 0;
        private SqlConnectionStringBuilder builder;

        public DoctorLogIn()
        {
            InitializeComponent();
            MySqlBuilder mySqlBuilder = MySqlBuilder.instance;
            builder = mySqlBuilder.builder;
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

        private void tbDocID_Validating(object sender, CancelEventArgs e)
        {
            if (tbDocID.Text.Trim().Length != 7)
            {
                errorProvider.SetError(tbDocID, "Wrong ID.");
                e.Cancel = true;
            }
        }

        private void tbDocID_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbDocID, null);
        }

        private void updateLastLogin(long doctorID)
        {
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
            //var builder = build();
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
            updateLastLogin(dbID);
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Debug("The doctor with ID {0} logged in.", dbID);
            Doctor doc = new Doctor(dbID, hashedPassword, specialisation, lastName, firstName, dbPIN, DateTime.Now);
            DoctorInterface doctorInterface = new DoctorInterface(doc);
            Hide();
            doctorInterface.ShowDialog();
        }

        private bool validateDoctor()
        {
            if (tbDocID.Text.Trim().Length != 7 || (tbDocID.Text.Trim().All(char.IsNumber) == false))
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

        private void wrongPIN()
        {
            successfulAuthentication++;
            MessageBox.Show("Incorrect PIN!");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            string checkID= tbDocID.Text.Trim().ToString();
            if (successfulAuthentication < 4 && validateDoctor() == true)
            {
                bool connected = false;
                long docID = long.Parse(tbDocID.Text.Trim());

                string saltedPassword = saltPassword(tbPassword.Text.Trim().ToString(), docID);
                byte[] hashedPassword = computeHash(saltedPassword);
                byte[] hashedPIN = computeHash(tbPIN.Text.Trim().ToString());

                var querry = "SELECT * from Doctors;";
                try
                {
                    using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                    {
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
                                    string lastName = (string)reader["doctor_last_name"];
                                    string firstName = (string)reader["doctor_first_name"];
                                    string specialisation = (string)reader["specialization"];

                                    if (reader["hashed_PIN"] == System.DBNull.Value)
                                    {
                                        hashedNewPIN = updatePIN(dbID);
                                        connected = true;
                                        startDoctorInterface(dbID, hashedPassword, specialisation, lastName, firstName,
                                            System.Text.Encoding.UTF8.GetBytes(hashedNewPIN), DateTime.Now);
                                    }
                                    else
                                        if (validatePIN() == true)
                                    {
                                        string dbPIN = (string)reader["hashed_PIN"];
                                        if ((Encoding.Default.GetString(hashedPIN)).CompareTo(dbPIN) == 0)
                                        {
                                            DateTime theDate = (DateTime)reader["last_login"];
                                            if ((DateTime.Today.Date - theDate.Date).Days > 30)
                                            {
                                                hashedNewPIN = updatePIN(docID);
                                                connected = true;
                                                startDoctorInterface(dbID, hashedPassword, specialisation, lastName, firstName,
                                                System.Text.Encoding.UTF8.GetBytes(hashedNewPIN), DateTime.Now);
                                            }
                                            else
                                            {
                                                connected = true;
                                                startDoctorInterface(dbID, hashedPassword, specialisation, lastName, firstName, hashedPIN, DateTime.Now);
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                catch(Exception ex)
                {
                    if (ex.Message.CompareTo("") == 0)
                        MessageBox.Show("You are not allowed to connect to the server. Please contact the administrator for permission.");
                }
                
                if(connected == false)
                {
                    successfulAuthentication++;
                    MessageBox.Show("Invalid credentials!");
                }
            }
            else
            {
                successfulAuthentication++;
                if (successfulAuthentication > 4)
                {
                    string myIP = getIP();
                    logger.Warn("The doctor with IP {0} is repeatedly trying to log in.", myIP);
                    MessageBox.Show("Invalid credentials and too many attempts! You need to wait 30 seconds to log in again.");
                    Wait(30);
                }

            }
        }

        private void readLog(string ip)
        {
            string[] lines = System.IO.File.ReadAllLines("log.txt");
            int j = lines.Length-1;
            for(int i=j; i>=0; i--)
            {
                string substring = lines[i].Substring(24, (lines[i].Length-24));
                string toCompare = "|WARN|BlockchainApp.DoctorLogIn|The doctor with IP "+ ip+" is repeatedly trying to log in.";
                if (substring.CompareTo(toCompare) ==0)
                {
                    string timestamp = lines[i].Substring(0, 19);
                    DateTimeConverter converter = new DateTimeConverter();
                    DateTime date = (DateTime)converter.ConvertFromString(timestamp);
                    double secondsPassed = (DateTime.Now - date).TotalSeconds;
                    if (secondsPassed < 40)
                    {
                        double secondsLeft = 40 - secondsPassed;
                        Wait(secondsLeft);
                        break;
                    }
                }
            }
        }

        private void Wait(double seconds)
        {
            tbDocID.Enabled = false;
            tbPassword.Enabled = false;
            tbPIN.Enabled = false;
            btnOK.Enabled = false;
            System.Threading.Thread.Sleep(1000*(int)seconds);
            tbDocID.Enabled = true;
            tbPassword.Enabled = true;
            tbPIN.Enabled = true;
            btnOK.Enabled = true;
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

        private string getIP()
        {
            string hostName = Dns.GetHostName();
            return Dns.GetHostByName(hostName).AddressList[0].ToString();
        }

        private void DoctorLogIn_Load(object sender, EventArgs e)
        {
            string myIP = getIP();
            readLog(myIP);
        }

        private void DoctorLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}