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
            Select();
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

        private byte[] computeHash(string toHash)
        {
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

        private bool validateDoctor()
        {
            if (tbNewDocID.Text.Trim().Length != 7)
            {
                MessageBox.Show("The ID is incorrect.");
                return false;
            }
            if (tbLastName.Text.Trim().Length < 1)
            {
                MessageBox.Show("The last name is invalid.");
                return false;
            }
            if (tbFirstName.Text.Trim().Length < 1)
            {
                MessageBox.Show("The first name is invalid.");
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
            if(tbSpecialisation.Text.Trim().Length < 1)
            {
                MessageBox.Show("The specialization is invalid!");
                return false;
            }
            if (tbRePassword.Text.Trim().CompareTo(tbPassword.Text.Trim()) != 0)
            {
                MessageBox.Show("The passwords don't match!");
                return false;
            }
            return true;
        }

        private bool validatePatient()
        {
            if (tbPacientID.Text.Trim().Length != 7)
            {
                MessageBox.Show("The ID is invalid.");
                return false;
            }
            if (tbPacientLastName.Text.Trim().Length < 1)
            {
                MessageBox.Show("The last name is invalid.");
                return false;
            }
            if (tbPacientFirstName.Text.Trim().Length < 1)
            {
                MessageBox.Show("The first name is invalid.");
                return false;
            }
            if (tbPacientPassword.Text.Trim().Length < 5 || !(tbPacientPassword.Text.Trim().Any(char.IsUpper)) || !(tbPacientPassword.Text.Trim().Any(char.IsLower))
                || !(tbPacientPassword.Text.Trim().Any(char.IsLetter)) || !(tbPacientPassword.Text.Trim().Any(char.IsNumber)) ||
                    !(tbPacientPassword.Text.Trim().Any(char.IsPunctuation)))
            {
                MessageBox.Show("Your password needs to include a number, a lowercase character, an uppercase character, a special symbol and " +
                    "at least 5 characters!");
                return false;
            }
            if (tbPacientREPass.Text.Trim().CompareTo(tbPacientPassword.Text.Trim()) != 0)
            {
                MessageBox.Show("The passwords don't match!");
                return false;
            }
            if (dtpBirthday.Value > DateTime.Now)
            {
                MessageBox.Show("The birthdate is invalid!");
                return false;
            }
            return true;
        }

        private void clearDoctorControls()
        {
            tbNewDocID.Text = null;
            tbFirstName.Text = null;
            tbLastName.Text = null;
            tbPassword.Text = null;
            tbRePassword.Text = null;
            tbSpecialisation.Text = null;
        }

        private void clearPatientControls()
        {
            tbPacientFirstName.Text = null;
            tbPacientID.Text = null;
            tbPacientPassword.Text = null;
            dtpBirthday.Value = DateTime.Now;
            tbPacientLastName.Text = null;
            tbPacientREPass.Text = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(validateDoctor()==true)
            { 
                long docID = long.Parse(tbNewDocID.Text.Trim());
                string lastName = tbLastName.Text.Trim().ToString();
                string firstName = tbLastName.Text.Trim().ToString();
                string specialization = tbSpecialisation.Text.Trim().ToString();
                string password = tbPassword.Text.Trim().ToString();
                var hasher = SHA256.Create();
                byte[] pass = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashedPassword = hasher.ComputeHash(pass);


                SqlConnectionStringBuilder builder = build();


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
                clearDoctorControls(); 
            }
        }

        private void btnOkPacient_Click(object sender, EventArgs e)
        {
            if (validatePatient()==true)
            {
                long pacID = long.Parse(tbPacientID.Text.Trim());
                string lastName = tbPacientLastName.Text.Trim().ToString();
                string firstName = tbPacientFirstName.Text.Trim().ToString();
                string password = tbPacientPassword.Text.Trim().ToString();
                string hashedPass = computeHash2(password);
                DateTime birthday = dtpBirthday.Value;


                SqlConnectionStringBuilder builder = build();


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
                        command.Parameters.AddWithValue("@hashedPass", hashedPass);
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
                clearPatientControls();
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

        //private void tbNewDocID_Validated(object sender, EventArgs e)
        //{
        //    errorProvider.SetError(tbNewDocID, null);
        //}

        //private void tbNewDocID_Validating(object sender, CancelEventArgs e)
        //{
        //    if (tbNewDocID.Text.Trim().Length != 7)
        //    {
        //        errorProvider.SetError(tbNewDocID, "Wrong ID.");
        //        e.Cancel = true;
        //    }
        //}

        //private void tbLastName_Validating(object sender, CancelEventArgs e)
        //{
        //    if(tbLastName.Text.Trim().Length < 1)
        //    {
        //        errorProvider.SetError(tbLastName, "Your name is not valid!");
        //        e.Cancel = true;
        //    }
        //}

        //private void tbLastName_Validated(object sender, EventArgs e)
        //{
        //    errorProvider.SetError(tbLastName, null);
        //}

        //private void tbFirstName_Validating(object sender, CancelEventArgs e)
        //{
        //    if (tbFirstName.Text.Trim().Length < 1)
        //    {
        //        errorProvider.SetError(tbLastName, "Your name is not valid!");
        //        e.Cancel = true;
        //    }
        //}

        //private void tbFirstName_Validated(object sender, EventArgs e)
        //{
        //    errorProvider.SetError(tbFirstName, null);
        //}

        //private void tbPassword_Validating(object sender, CancelEventArgs e)
        //{
        //    if (tbPassword.Text.Trim().Length < 5 || !(tbPassword.Text.Trim().Any(char.IsUpper)) || !(tbPassword.Text.Trim().Any(char.IsLower))
        //        || !(tbPassword.Text.Trim().Any(char.IsLetter)) || !(tbPassword.Text.Trim().Any(char.IsNumber)) ||
        //            !(tbPassword.Text.Trim().Any(char.IsPunctuation)))
        //    {
        //        errorProvider.SetError(tbPassword, "Your passwords need to include a number, an uppercase character, a special symbol and " +
        //            "at least 5 characters!");
        //        e.Cancel = true;
        //    }
        //}

        //private void tbPassword_Validated(object sender, EventArgs e)
        //{
        //    errorProvider.SetError(tbPassword, null);
        //}

        //private void tbRePassword_Validating(object sender, CancelEventArgs e)
        //{
        //    if(tbRePassword.Text.Trim().CompareTo(tbPassword.Text.Trim())!=0)
        //    {
        //        errorProvider.SetError(tbRePassword, "The passwords don't match!");
        //        e.Cancel = true;
        //    }
        //}

        //private void tbRePassword_Validated(object sender, EventArgs e)
        //{
        //    errorProvider.SetError(tbRePassword, null);
        //}

        //private void tbPacientID_Validating(object sender, CancelEventArgs e)
        //{
        //    if (tbPacientID.Text.Trim().Length != 7)
        //    {
        //        errorProvider2.SetError(tbPacientID, "Wrong ID.");
        //        e.Cancel = true;
        //    }
        //}

        //private void tbPacientID_Validated(object sender, EventArgs e)
        //{
        //    errorProvider2.SetError(tbPacientID, null);
        //}

        //private void tbPacientLastName_Validating(object sender, CancelEventArgs e)
        //{
        //    if (tbPacientLastName.Text.Trim().Length < 1)
        //    {
        //        errorProvider2.SetError(tbPacientLastName, "Your name is not valid!");
        //        e.Cancel = true;
        //    }
        //}

        //private void tbPacientLastName_Validated(object sender, EventArgs e)
        //{
        //    errorProvider2.SetError(tbPacientLastName, null);
        //}

        //private void tbPacientFirstName_Validating(object sender, CancelEventArgs e)
        //{
        //    if (tbPacientFirstName.Text.Trim().Length < 1)
        //    {
        //        errorProvider2.SetError(tbPacientFirstName, "Your name is not valid!");
        //        e.Cancel = true;
        //    }
        //}

        //private void tbPacientFirstName_Validated(object sender, EventArgs e)
        //{
        //    errorProvider2.SetError(tbPacientFirstName, null);
        //}

        //private void tbPacientPassword_Validating(object sender, CancelEventArgs e)
        //{
        //    if (tbPacientPassword.Text.Trim().Length < 5 || !(tbPacientPassword.Text.Trim().Any(char.IsUpper)) || !(tbPacientPassword.Text.Trim().Any(char.IsLower))
        //        || !(tbPacientPassword.Text.Trim().Any(char.IsLetter)) || !(tbPacientPassword.Text.Trim().Any(char.IsNumber)) ||
        //            !(tbPacientPassword.Text.Trim().Any(char.IsPunctuation)))
        //    {
        //        errorProvider2.SetError(tbPacientPassword, "Your passwords need to include a number, an uppercase character, a special symbol and " +
        //            "at least 5 characters!");
        //        e.Cancel = true;
        //    }
        //}

        //private void tbPacientPassword_Validated(object sender, EventArgs e)
        //{
        //    errorProvider2.SetError(tbPacientPassword, null);
        //}

        //private void tbPacientREPass_Validating(object sender, CancelEventArgs e)
        //{
        //    if (tbPacientPassword.Text.Trim().CompareTo(tbPacientREPass.Text.Trim()) != 0)
        //    {
        //        errorProvider2.SetError(tbPacientREPass, "The passwords don't match!");
        //        e.Cancel = true;
        //    }
        //}

        //private void tbPacientREPass_Validated(object sender, EventArgs e)
        //{
        //    errorProvider2.SetError(tbPacientREPass, null);
        //}

        //private void dtpBirthday_Validating(object sender, CancelEventArgs e)
        //{
        //    if(dtpBirthday.Value < DateTime.Now)
        //    {
        //        errorProvider2.SetError(dtpBirthday, "Invalid birthdate!");
        //        e.Cancel = true;
        //    }
        //}

        //private void dtpBirthday_Validated(object sender, EventArgs e)
        //{
        //    errorProvider2.SetError(dtpBirthday, null);
        //}

    }
}