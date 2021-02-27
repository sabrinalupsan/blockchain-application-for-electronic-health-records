﻿using System;
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
using MaterialSkin;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Security.AccessControl;
using NLog;

namespace BlockchainApp
{
    public partial class AdminInterface : MaterialSkin.Controls.MaterialForm
    {
        private SqlConnectionStringBuilder builder;
        private List<Block> blocks = new List<Block>();
        private string backupFileName = "backup.bin";
        Aes aes;

        public AdminInterface()
        {
            InitializeComponent();
            Select();
            MySqlBuilder mySqlBuilder = MySqlBuilder.instance;
            builder = mySqlBuilder.builder;
            aes = Aes.Create();
            byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            aes.Key = key;
            updateLastBackup();
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
            if (tbPatientID.Text.Trim().Length != 7)
            {
                MessageBox.Show("The ID is invalid.");
                return false;
            }
            if (tbPatientLastName.Text.Trim().Length < 1)
            {
                MessageBox.Show("The last name is invalid.");
                return false;
            }
            if (tbPatientFirstName.Text.Trim().Length < 1)
            {
                MessageBox.Show("The first name is invalid.");
                return false;
            }
            if (tbPatientPassword.Text.Trim().Length < 5 || !(tbPatientPassword.Text.Trim().Any(char.IsUpper)) || !(tbPatientPassword.Text.Trim().Any(char.IsLower))
                || !(tbPatientPassword.Text.Trim().Any(char.IsLetter)) || !(tbPatientPassword.Text.Trim().Any(char.IsNumber)) ||
                    !(tbPatientPassword.Text.Trim().Any(char.IsPunctuation)))
            {
                MessageBox.Show("Your password needs to include a number, a lowercase character, an uppercase character, a special symbol and " +
                    "at least 5 characters!");
                return false;
            }
            if (tbPatientREPass.Text.Trim().CompareTo(tbPatientPassword.Text.Trim()) != 0)
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
            tbPatientFirstName.Text = null;
            tbPatientID.Text = null;
            tbPatientPassword.Text = null;
            dtpBirthday.Value = DateTime.Now;
            tbPatientLastName.Text = null;
            tbPatientREPass.Text = null;
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

        private void clickField()
        {
            progressBar.Value = 0;
            progressLabel.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateDoctor() == true)
                {
                    long docID = long.Parse(tbNewDocID.Text.Trim());
                    string lastName = tbLastName.Text.Trim().ToString();
                    string firstName = tbLastName.Text.Trim().ToString();
                    string specialization = tbSpecialisation.Text.Trim().ToString();
                    string password = tbPassword.Text.Trim().ToString();
                    string saltedPassword = saltPassword(password, docID);
                    var hasher = SHA256.Create();
                    byte[] pass = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
                    byte[] hashedPassword = hasher.ComputeHash(pass);

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
                                while (reader.Read())
                                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                        }
                    }
                    progressBar.Value = 100;
                    progressLabel.Text = "Doctor added!";
                    clearDoctorControls();
                }
            }
            catch(Exception ex)
            {
                string s = "Violation of PRIMARY KEY constraint";
                if (ex.Message.Substring(0, s.Length).CompareTo(s) == 0)
                {
                    MessageBox.Show("Database error! This doctor is already present in the database.");
                }
            }
        }

        private void GenesisBlock()
        {
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                var querryString =
                    "INSERT INTO Block (patient_id, doctor_id, appointment_date, appointment_description, appointment_title, block_timestamp, block_index, " +
                    "hash_of_prev_block, hash_of_curr_block)" +
                    "VALUES (-1, -1, @date, 'no description', 'no title', @dateNow, 0, 0, @hashOfCurrBlock);";
                using (SqlCommand command = new SqlCommand(querryString, conn))
                {
                    conn.Open();
                    string now = DateTime.Now.ToString("yyyy-MM-dd");
                    command.Parameters.AddWithValue("@date", now);
                    command.Parameters.AddWithValue("@dateNow", now);

                    string toHash = "-1" + "-1" + "1" + "no description" + "1" + "0" + "0";
                    command.Parameters.AddWithValue("@hashOfCurrBlock", computeHash2(toHash));

                    using (SqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                }
            }
        }

        private void btnOkPacient_Click(object sender, EventArgs e)
        {
            try
            {
                if (validatePatient() == true)
                {
                    long patientID = long.Parse(tbPatientID.Text.Trim());
                    string lastName = tbPatientLastName.Text.Trim().ToString();
                    string firstName = tbPatientFirstName.Text.Trim().ToString();
                    string password = tbPatientPassword.Text.Trim().ToString();
                    string saltedPassword = saltPassword(password, patientID);
                    string hashedPass = computeHash2(saltedPassword);
                    DateTime birthday = dtpBirthday.Value;

                    using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                    {

                        var querryString =
                            "INSERT INTO Patients (patient_id, patient_last_name, patient_first_name, hashed_pass, last_login, birthday)" +
                            "VALUES (@pacID, @lastName, @firstName, @hashedPass, @dateNow, @birthday);";
                        using (SqlCommand command = new SqlCommand(querryString, conn))
                        {
                            conn.Open();
                            command.Parameters.AddWithValue("@pacID", tbPatientID.Text.Trim().ToString());
                            command.Parameters.AddWithValue("@lastName", tbPatientLastName.Text.Trim().ToString());
                            command.Parameters.AddWithValue("@firstName", tbPatientFirstName.Text.Trim().ToString());
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
                    progressBar.Value = 100;
                    progressLabel.Text = "Patient added!";
                    clearPatientControls();
                }
            }
            catch(Exception ex)
            {
                string s = "Violation of PRIMARY KEY constraint";
                if (ex.Message.Substring(0, s.Length).CompareTo(s)==0)
                {
                    MessageBox.Show("Database error! This patient is already present in the database.");
                }
            }
        }

        private void btnCancelPatient_Click(object sender, EventArgs e)
        {
            clearPatientControls();
        }

        private void controlClicked(object sender, EventArgs e)
        {
            clickField();
        }

        private void btnCancelDoctor_Click(object sender, EventArgs e)
        {
            clearDoctorControls();
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

        private bool checkBlockchain()
        {
            var selectEverythingQuery = "SELECT * FROM Block ORDER BY block_index";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(selectEverythingQuery, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    string genesisContent = "-1" + "-1" + "1" + "no description" + "1" + "0" + "0";
                    string hashedgenesisContent = computeHash2(genesisContent);

                    reader.Read();
                    string previousHash = (string)reader["hash_of_curr_block"];
                    if(previousHash.CompareTo(hashedgenesisContent) !=0)
                    {
                        return false;
                    }
                    DateTime genesisDate = (DateTime)reader["appointment_date"];
                    DateTime genesisTimestamp = (DateTime)reader["block_timestamp"];
                    string current;
                    string previous;
                    while (reader.Read())
                    {
                        current = (string)reader["hash_of_curr_block"];
                        previous = (string)reader["hash_of_prev_block"];

                        long patientID = (int)reader["patient_id"];
                        long doctorID = (int)reader["doctor_id"];
                        string title = (string)reader["appointment_title"];
                        string description = (string)reader["appointment_description"];
                        DateTime date = (DateTime)reader["appointment_date"];
                        DateTime timestamp = (DateTime)reader["block_timestamp"];
                        int nounce = (int)reader["nounce"];
                        int blockIndex = (int)reader["block_index"];

                        string toHash = patientID + doctorID + date.ToString("yyyy-MM-dd") + title + description + timestamp.ToString("yyyy-MM-dd") + blockIndex + previous;
                        Hash hash = new Hash(nounce, toHash);
                        if (current.CompareTo(hash.computeHash()) != 0)
                            return false;

                        if (previousHash.CompareTo(previous) != 0)
                            return false;

                        Block block = new Block(patientID, doctorID, title, description, date, timestamp, nounce, blockIndex, previous, current);
                        blocks.Add(block);

                        previousHash = current;

                    }
                }
            }

            return true;
        }

        private void AdminInterface_Click(object sender, EventArgs e)
        {
            clickField();
        }

        public void updateLastBackup()
        {
            DateTime modification = File.GetLastWriteTime(backupFileName);
            tbLastBackup.Text = modification.ToString();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBlockchain() == true)
                {
                    //generate IV and write to a new file
                    aes.GenerateIV();
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream s = File.Create("IV.bin"))
                        bf.Serialize(s, aes.IV);

                    //write to file the whole list
                    using (FileStream fs = new FileStream(backupFileName, FileMode.Create))
                    {
                        using (CryptoStream cs = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        { 
                            new BinaryFormatter().Serialize(cs, blocks);
                        }
                    }

                    //BinaryFormatter formatter = new BinaryFormatter();
                    //using (FileStream s = File.Create("backup.bin"))
                    //{
                    //    using (CryptoStream cs = new CryptoStream(s, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                    //        formatter.Serialize(cs, blocks);
                    //}
                    progressBar.Value = 100;
                    progressLabel.Text = "Created backup.";
                    updateLastBackup();
                }
                else
                    MessageBox.Show("CRITICAL ERROR. BLOCKCHAIN HAS BEEN COMPROMISED.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error writing to file"+" "+ex.Message);
            }
        }

        private void proofOfWork(Hash hash, int difficulty)
        {
            var leadingZeros = new string('0', difficulty);

            while (hash.theHash.Substring(0, difficulty) != leadingZeros)
            {
                hash.nounce++;
                hash.theHash = hash.computeHash();
            }
        }

        private void deleteBlockTable(int n)
        {
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                var deteleQuery =
                    "DELETE FROM Block;";
                using (SqlCommand command = new SqlCommand(deteleQuery, conn))
                {
                    conn.Open();
                    command.ExecuteNonQuery();

                    using (SqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                }
            }

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                var resetQuery = "ALTER SEQUENCE block_indexes RESTART WITH " + n + ";";

                using (SqlCommand command = new SqlCommand(resetQuery, conn))
                {
                    conn.Open();
                    command.ExecuteNonQuery();

                    using (SqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                }
            }
        }

        private void btnOverwrite_Click(object sender, EventArgs e)
        {
            clickField();
            Confirm_Overwrite confirm_Overwrite = new Confirm_Overwrite();
            confirm_Overwrite.ShowDialog();
            if(confirm_Overwrite.DialogResult==DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream s = File.OpenRead("IV.bin"))
                {
                    aes.IV = (byte[])formatter.Deserialize(s);
                }
                using (FileStream fs = new FileStream(backupFileName, FileMode.Open))
                {
                    using (CryptoStream cs = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        List<Block> deserialized = (List<Block>)new BinaryFormatter().Deserialize(cs);

                        deleteBlockTable(deserialized.Count+1);

                        GenesisBlock();

                        using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                        {
                            var querryString =
                                "INSERT INTO Block (patient_id, doctor_id, appointment_date, appointment_title, appointment_description, nounce, block_timestamp, block_index, " +
                                "hash_of_prev_block, hash_of_curr_block)" +
                                "VALUES (@pacID, @docID, @date, @title, @description, @nounce, @dateNow, @index, @hashOfPrevBlock, @hashOfCurrBlock);";
                            using (SqlCommand command = new SqlCommand(querryString, conn))
                            {
                                conn.Open();
                                for (int i = 0; i < deserialized.Count; i++)
                                {
                                    Block currentBlock = deserialized[i];
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@pacID", currentBlock.patientID);
                                    command.Parameters.AddWithValue("@docID", currentBlock.doctorID);
                                    command.Parameters.AddWithValue("@date", currentBlock.date);
                                    command.Parameters.AddWithValue("@title", currentBlock.title);
                                    command.Parameters.AddWithValue("@index", currentBlock.index);
                                    command.Parameters.AddWithValue("@description", currentBlock.description);
                                    command.Parameters.AddWithValue("@dateNow", currentBlock.timestamp);
                                    command.Parameters.AddWithValue("@hashOfPrevBlock", currentBlock.hashOfPrevBlock);
                                    command.Parameters.AddWithValue("@nounce", currentBlock.nounce);
                                    command.Parameters.AddWithValue("@hashOfCurrBlock", currentBlock.hashOfCurrBlock);

                                    using (SqlDataReader reader = command.ExecuteReader())
                                        while (reader.Read())
                                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                                }
                            }
                        }
                        progressBar.Value = 100;
                        progressLabel.Text = "Database overwritten.";
                        Logger logger = LogManager.GetCurrentClassLogger();
                        logger.Warn("Database has been overwritten");
                    }

                }
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            clickField();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            clickField();
        }
    }
}