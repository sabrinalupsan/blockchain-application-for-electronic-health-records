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

namespace BlockchainApp
{
    public partial class PacientLogIn : Form
    {
        private int successfulAuthentication;

        public PacientLogIn()
        {
            InitializeComponent();
            successfulAuthentication = 0;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (successfulAuthentication < 3)
            {
                long pacientID = long.Parse(tbPacientID.Text.Trim());

                //https://stackoverflow.com/questions/3984138/hash-string-in-c-sharp
                var hasher = SHA256.Create();
                byte[] pass = System.Text.Encoding.UTF8.GetBytes(tbPassword.Text.Trim().ToString());
                byte[] hashedPassword = hasher.ComputeHash(pass);
                //MessageBox.Show(Encoding.Default.GetString(hashedPassword));

                byte[] PIN = System.Text.Encoding.UTF8.GetBytes(tbPIN.Text.Trim().ToString());
                byte[] hashedPIN = hasher.ComputeHash(PIN);

                SqlConnectionStringBuilder builder = build();

                //select querry
                var querry = "SELECT * from Pacients;";

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    bool connected = false;
                    conn.Open();
                    var command = new SqlCommand(querry, conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int the_ID = (int)reader["pacient_id"];
                            long id = the_ID;
                            string password = (string)reader["hashed_pass"];
                            if (id.CompareTo(pacientID) == 0 && (Encoding.Default.GetString(hashedPassword)).CompareTo(password) == 0)
                            {
                                connected = true;
                                string lastName = (string)reader["pacient_last_name"];
                                string firstName = (string)reader["pacient_first_name"];
                                byte[] thePass = System.Text.Encoding.UTF8.GetBytes(password);
                                byte[] thePIN = null;//= System.Text.Encoding.UTF8.GetBytes(PIN_token);
                                DateTime theDate = (DateTime)reader["last_login"];
                                DateTime birthday = (DateTime)reader["birthday"];
                                Patient pacient = new Patient(id, thePass, thePIN, lastName, firstName, birthday);
                                PacientInterface pacientInterface = new PacientInterface(pacient);
                                pacientInterface.ShowDialog();
                                Hide();
                            }
                        }
                    }
                    if (connected == false)
                        MessageBox.Show("Invalid credentials!");
                }

                //here i need to check with the database that the pass, ID and token are ok: SQL querry
                //if yes:
                //get the doc from the database and see how many days are in his last login: SQL querry
                //firstly we see if we need to create a new token PIN
                //if ((DateTime.Today.Date - doc.lastLogin.Date).Days > 30)
                //{
                //    MessageBox.Show("Your new token PIN for the next 30 days is: " + "randomized_PIN_here");
                //    //hash the PIN
                //    //change the value for hashed_pin and last_login from the table
                //}
                //if no:
                successfulAuthentication++;

            }
            else
                MessageBox.Show("Yo dont DDOS me");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
