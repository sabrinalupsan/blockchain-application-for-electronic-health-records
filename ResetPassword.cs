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
    public partial class ResetPassword : Form
    {
        private SqlConnectionStringBuilder builder;

        public ResetPassword()
        {
            InitializeComponent();
            MySqlBuilder mySqlBuilder = MySqlBuilder.instance;
            builder = mySqlBuilder.builder;
        }

        //private SqlConnectionStringBuilder build()
        //{
        //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        //    builder.DataSource = "blockchainapp.database.windows.net";
        //    builder.UserID = "lupsansabrina18";
        //    builder.Password = "Selenacolierul9!";
        //    builder.InitialCatalog = "blockchainapp";
        //    return builder;
        //}

        private string computeHash(string toHash)
        {
            var hasher = SHA256.Create();
            byte[] byteHash = System.Text.Encoding.UTF8.GetBytes(toHash);
            byte[] finalHash = hasher.ComputeHash(byteHash);
            return Encoding.Default.GetString(finalHash);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool checkData()
        {
            if (tbID.Text.Trim().Length != 7 || (tbID.Text.Trim().All(char.IsNumber) == false))
            {
                MessageBox.Show("The ID is invalid.");
                return false;
            }
            if (tbPIN.Text.Trim().Length != 4 || (tbPIN.Text.Trim().All(char.IsNumber) == false))
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
            if (tbRePassword.Text.Trim().CompareTo(tbRePassword.Text.Trim()) != 0)
            {
                MessageBox.Show("The passwords don't match!");
                return false;
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(checkData()==true)
            {
                long ID = int.Parse(tbID.Text.Trim().ToString());
                int PIN = int.Parse(tbPIN.Text.Trim().ToString());
                string hashedPassword = computeHash(tbPassword.Text.Trim().ToString());
                string hashedPIN = computeHash(PIN.ToString());
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {

                    var querryDoctors =
                        "UPDATE Doctors SET hashed_pass = @hashedpassword WHERE hashed_pin = @hashedPIN;";
                    var querryPatients =
                        "UPDATE Doctors SET hashed_pass = @hashedpassword WHERE hashed_pin = @hashedPIN;";
                    using (SqlCommand doctorsCommand = new SqlCommand(querryDoctors, conn))
                    {
                        conn.Open();
                        doctorsCommand.Parameters.AddWithValue("@hashedpassword", hashedPassword);
                        doctorsCommand.Parameters.AddWithValue("@hashedPIN", hashedPIN);

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
                        patientsCommand.Parameters.AddWithValue("@hashedPIN", hashedPIN);

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
                logger.Debug("The user with the ID {0} just changed their password.", ID);
                Close();
            }
        }
    }
}
