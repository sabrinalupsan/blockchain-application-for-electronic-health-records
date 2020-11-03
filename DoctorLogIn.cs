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

        private void tbDocID_Validating(object sender, CancelEventArgs e)
        {
            //if(tbDocID.Text.Trim().Length != 7)
            //{
            //    errorProvider.SetError(tbDocID, "Wrong ID.");
            //    e.Cancel = true;
            //}
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = build();

            if (successfulAuthentication<3)
            {
                long docID = long.Parse(tbDocID.Text.Trim());

                //https://stackoverflow.com/questions/3984138/hash-string-in-c-sharp
                var hasher = SHA256.Create();
                byte[] pass = System.Text.Encoding.UTF8.GetBytes(tbPassword.Text.Trim().ToString());
                byte[] hashedPassword = hasher.ComputeHash(pass);

                byte[] PIN = System.Text.Encoding.UTF8.GetBytes(tbPIN.Text.Trim().ToString());
                byte[] hashedPIN = hasher.ComputeHash(PIN);

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
                            long id = (int)reader["doctor_id"];
                            string password = (string)reader["hashed_pass"];

                            if (id.CompareTo(docID) == 0 && (Encoding.Default.GetString(hashedPassword)).CompareTo(password) == 0)
                            {
                                if (reader["hashed_PIN"] == System.DBNull.Value)
                                {
                                    int newPIN = 12;
                                    MessageBox.Show("Your new token PIN for the next 30 days is: " + newPIN.ToString());

                                    PIN = System.Text.Encoding.UTF8.GetBytes(newPIN.ToString());
                                    hashedPIN = hasher.ComputeHash(PIN);

                                    var updatePINquery = "UPDATE Doctors SET hashed_PIN = @hashPIN WHERE doctor_id = " + id + ";";
                                    using (SqlConnection updatePINconnection = new SqlConnection(builder.ConnectionString))
                                    {
                                        updatePINconnection.Open();
                                        using (SqlCommand updatePINCommand = new SqlCommand(updatePINquery, updatePINconnection))
                                        {
                                            updatePINCommand.Parameters.AddWithValue("@hashPIN", hashedPIN);

                                            using (SqlDataReader updatePINReader = updatePINCommand.ExecuteReader())
                                            {
                                                while (updatePINReader.Read())
                                                {
                                                    Console.WriteLine("{0} {1}", updatePINReader.GetString(0), updatePINReader.GetString(1));
                                                }
                                            }
                                        }
                                    }
                                    

                                    connected = true;
                                    string lastName = (string)reader["doctor_last_name"];
                                    string firstName = (string)reader["doctor_first_name"];
                                    string specialisation = (string)reader["specialization"];
                                    byte[] thePass = System.Text.Encoding.UTF8.GetBytes(password);

                                    DateTime theDate = (DateTime)reader["last_login"];
                                    //update table that changes the last login
                                    var lastLoginQuery = "UPDATE Doctors" + " SET last_login = SYSDATETIME()" + "WHERE doctor_id =" + id + ";";
                                    using (SqlConnection lastLoginConnection = new SqlConnection(builder.ConnectionString))
                                    {
                                        lastLoginConnection.Open();
                                        using (SqlCommand lastLoginCommand = new SqlCommand(lastLoginQuery, lastLoginConnection))
                                        {
                                            lastLoginCommand.Parameters.AddWithValue("@last_login", DateTime.Now.ToString("yyyy-MM-dd"));

                                            using (SqlDataReader lastLoginreader = lastLoginCommand.ExecuteReader())
                                            {
                                                while (lastLoginreader.Read())
                                                {
                                                    Console.WriteLine("{0} {1}", lastLoginreader.GetString(0), lastLoginreader.GetString(1));
                                                }
                                            }
                                        }
                                    }
                                    //----------------------------------------------------------
                                    //the select to fill the entire list of pacients of the doctor

                                    //------------------------------------------------------------

                                    Doctor doc = new Doctor(id, thePass, specialisation, lastName, firstName, hashedPIN, DateTime.Now);
                                    DoctorInterface doctorInterface = new DoctorInterface(doc);
                                    doctorInterface.ShowDialog();
                                    Hide();
                                }
                                else
                                {
                                    string smth = (string)reader["hashed_PIN"];
                                    if (Encoding.Default.GetString(hashedPIN).CompareTo(smth) == 0)
                                    {
                                        connected = true;
                                        string lastName = (string)reader["doctor_last_name"];
                                        string firstName = (string)reader["doctor_first_name"];
                                        string specialisation = (string)reader["specialization"];
                                        byte[] thePass = System.Text.Encoding.UTF8.GetBytes(password);
                                        //string PIN_token = (string)reader["hashed_PIN"];
                                        //thePIN = System.Text.Encoding.UTF8.GetBytes(PIN_token);
                                        DateTime theDate = (DateTime)reader["last_login"];
                                        //the select to fill the entire list of pacients of the doctor
                                        if ((DateTime.Today.Date - theDate.Date).Days > 30)
                                        {
                                            int newPIN = 12;
                                            MessageBox.Show("Your new token PIN for the next 30 days is: " + newPIN.ToString());
                                            //hash the PIN
                                            PIN = System.Text.Encoding.UTF8.GetBytes(newPIN.ToString());
                                            hashedPIN = hasher.ComputeHash(PIN);
                                            var updateQuery = "UPDATE Doctors SET hashed_pin = @hashPIN;";
                                            var updateCommand = new SqlCommand(updateQuery, conn);
                                            updateCommand.Parameters.AddWithValue("@hashPIN", hashedPIN.ToString());
                                        }
                                        //we need to input the new login
                                        var lastLoginQuery = "UPDATE Doctors" + " SET last_login = SYSDATETIME()" + "WHERE doctor_id ="+id+";";
                                        using (SqlConnection lastLoginConnection = new SqlConnection(builder.ConnectionString))
                                        {
                                            lastLoginConnection.Open();
                                            using (SqlCommand lastLoginCommand = new SqlCommand(lastLoginQuery, lastLoginConnection))
                                            {
                                                lastLoginCommand.Parameters.AddWithValue("@last_login", DateTime.Now.ToString("yyyy-MM-dd"));

                                                using (SqlDataReader lastLoginreader = lastLoginCommand.ExecuteReader())
                                                {
                                                    while (lastLoginreader.Read())
                                                    {
                                                        Console.WriteLine("{0} {1}", lastLoginreader.GetString(0), lastLoginreader.GetString(1));
                                                    }
                                                }
                                            }
                                        }
                                        //--------------------------------
                                        Doctor doc = new Doctor(id, thePass, specialisation, lastName, firstName, hashedPIN, DateTime.Now);
                                        DoctorInterface doctorInterface = new DoctorInterface(doc);
                                        doctorInterface.ShowDialog();
                                        Hide();
                                    }
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

     
    }
}
