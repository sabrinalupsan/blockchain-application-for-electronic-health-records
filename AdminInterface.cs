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
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace BlockchainApp
{
    public partial class AdminInterface : Form
    {
        public AdminInterface()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text.Trim().ToString().CompareTo(tbRePassword.Text.Trim().ToString()) != 0)
                MessageBox.Show("Passwords do not match!");
            else
            {
                long docID = long.Parse(tbNewDocID.Text.Trim());
                string lastName = tbLastName.Text.Trim().ToString();
                string firstName = tbLastName.Text.Trim().ToString();
                string specialization = tbSpecialisation.Text.Trim().ToString();
                string password = tbPassword.Text.Trim().ToString();
                var hasher = SHA256.Create();
                byte[] pass = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashedPassword = hasher.ComputeHash(pass);


                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "blockchainapp.database.windows.net";
                builder.UserID = "lupsansabrina18";
                builder.Password = "Selenacolierul9!";
                builder.InitialCatalog = "blockchainapp";


                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {

                    var querryString = 
                        "INSERT INTO Doctors (doctor_id, doctor_last_name, doctor_first_name, specialization, hashed_pass, last_login)" +
                        "VALUES (@docID, @lastName, @firstName, @specialization, @hashedPass, @dateNow);";
                    using (SqlCommand command = new SqlCommand(querryString, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("@docID", tbNewDocID.Text.Trim().ToString());
                        command.Parameters.AddWithValue("@lastName", tbLastName.Text.Trim().ToString());
                        command.Parameters.AddWithValue("@firstName", tbFirstName.Text.Trim().ToString());
                        command.Parameters.AddWithValue("@specialization", tbSpecialisation.Text.Trim().ToString());
                        command.Parameters.AddWithValue("@hashedPass", Encoding.Default.GetString(hashedPassword));
                        command.Parameters.AddWithValue("@dateNow", DateTime.Now.ToString("yyyy-MM-dd"));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
                Close();
            }
        }

        private void btnOkPacient_Click(object sender, EventArgs e)
        {
            if (tbPacientPassword.Text.Trim().ToString().CompareTo(tbPacientREPass.Text.Trim().ToString()) != 0)
                MessageBox.Show("Passwords do not match!");
            else
            {
                long pacID = long.Parse(tbPacientID.Text.Trim());
                string lastName = tbPacientLastName.Text.Trim().ToString();
                string firstName = tbPacientFirstName.Text.Trim().ToString();
                string password = tbPassword.Text.Trim().ToString();
                var hasher = SHA256.Create();
                byte[] pass = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashedPassword = hasher.ComputeHash(pass);
                DateTime birthday = dtpBirthday.Value;


                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "blockchainapp.database.windows.net";
                builder.UserID = "lupsansabrina18";
                builder.Password = "Selenacolierul9!";
                builder.InitialCatalog = "blockchainapp";


                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {

                    var querryString =
                        "INSERT INTO Pacients (pacient_id, pacient_last_name, pacient_first_name, hashed_pass, last_login, birthday)" +
                        "VALUES (@pacID, @lastName, @firstName, @hashedPass, @dateNow, @birthday);";
                    using (SqlCommand command = new SqlCommand(querryString, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("@pacID", tbPacientID.Text.Trim().ToString());
                        command.Parameters.AddWithValue("@lastName", tbPacientLastName.Text.Trim().ToString());
                        command.Parameters.AddWithValue("@firstName", tbPacientFirstName.Text.Trim().ToString());
                        command.Parameters.AddWithValue("@hashedPass", Encoding.Default.GetString(hashedPassword));
                        command.Parameters.AddWithValue("@dateNow", DateTime.Now.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@birthday", birthday.ToString("yyyy-MM-dd"));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelPacient_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
