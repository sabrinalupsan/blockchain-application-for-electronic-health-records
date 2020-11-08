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
using System.Data.SqlClient;
using NLog;

namespace BlockchainApp
{
    public partial class DoctorInterface : Form
    {
        Doctor doctor;
        int successfulAuthentication = 0;

        private SqlConnectionStringBuilder build()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "blockchainapp.database.windows.net";
            builder.UserID = "lupsansabrina18";
            builder.Password = "Selenacolierul9!";
            builder.InitialCatalog = "blockchainapp";
            return builder;
        }

        public DoctorInterface(Doctor doctor)
        {
            InitializeComponent();
            this.doctor = doctor;
            doctor.patients = new List<Patient>();

            SqlConnectionStringBuilder builder = build();

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {

                var querryString =
                    "SELECT * FROM BLOCK;";
                using (SqlCommand command = new SqlCommand(querryString, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                            if(reader.HasRows)
                            {

                            }
                            else
                                GenesisBlock();

                    }
                }
            }

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

        private void GenesisBlock()
        {
            SqlConnectionStringBuilder builder = build();

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {

                var querryString =
                    "INSERT INTO Block (pacient_id, doctor_id, appointment_date, appointment_description, appointment_title, block_timestamp, block_index, " +
                    "hash_of_prev_block, hash_of_curr_block)" +
                    "VALUES (-1, -1, @date, 'no description', 'no title', @dateNow, 0, 0, @hashOfCurrBlock);";
                using (SqlCommand command = new SqlCommand(querryString, conn))
                {
                    conn.Open();
                    string now = DateTime.Now.ToString("yyyy-MM-dd");
                    command.Parameters.AddWithValue("@date", now);
                    command.Parameters.AddWithValue("@dateNow", now);

                    //compute hash of current block;
                    string toHash = "-1" + "-1" + now + "no description" + now + "0" + "0";

                    command.Parameters.AddWithValue("@hashOfCurrBlock", computeHash2(toHash));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
            }
        }

        private bool checkID(long id)
        {
            bool ok = false;
            var builder = build();
            var querry = "SELECT pacient_id from Pacients;";
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand(querry, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int patient_id = (int)reader["pacient_id"];
                        if (id == patient_id)
                            ok = true;
                    }
                }
            }
            return ok;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                long patientID = long.Parse(tbNewPacientID.Text.Trim());
                if (checkID(patientID) == true)
                {
                    SqlConnectionStringBuilder builder = build();

                    using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                    {

                        var querryString =
                            "INSERT INTO Associations (doctor_id, pacient_id)" +
                            "VALUES (@docID, @patientID);";
                        using (SqlCommand command = new SqlCommand(querryString, conn))
                        {
                            conn.Open();
                            command.Parameters.AddWithValue("@docID", doctor.docID);
                            command.Parameters.AddWithValue("@patientID", patientID.ToString());

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                                }
                            }
                        }
                    }
                    updateListView();
                    Logger logger = LogManager.GetCurrentClassLogger();
                    logger.Debug("Doctor {0} added patient {1} to his list.", doctor.docID, patientID);
                }
                else
                    MessageBox.Show("That ID does not correspond to any existing patient.");
            }
            catch(FormatException)
            {
                MessageBox.Show("Please input a valid patient ID!");
            }
            catch(SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("You already have that patient!");
            }
        }

        public void DisplayPacients()
        {
            lvPacients.Items.Clear();
            foreach (Patient patient in doctor.patients)
            {
                var listViewItem = new ListViewItem(patient.patientID.ToString());
                listViewItem.SubItems.Add(patient.lastName);
                listViewItem.SubItems.Add(patient.firstName);
                listViewItem.Tag = patient;
                lvPacients.Items.Add(listViewItem);
            }
            tbTitle.Hide();
        }

        private void updateListView()
        {
            var querry = "SELECT pacient_id, pacient_last_name, pacient_first_name, birthday" + " FROM Pacients " +
                "WHERE pacient_id IN(SELECT pacient_id from ASSOCIATIONS WHERE doctor_id =" + doctor.docID + ");";

            doctor.patients.Clear();

            SqlConnectionStringBuilder builder = build();

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand(querry, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (int)reader["pacient_id"];
                        string patientLastName = (string)reader["pacient_last_name"];
                        string pacienFirstName = (string)reader["pacient_first_name"];
                        DateTime bday = (DateTime)reader["birthday"];

                        Patient patient = new Patient(id, patientLastName, pacienFirstName, bday);
                        doctor.patients.Add(patient);
                    }
                }
            }
            DisplayPacients();
        }

        private void DoctorInterface_Load(object sender, EventArgs e)
        {
            tbTitle.Hide();
            tbDetails.Hide();
            dtpDate.Hide();
            label5.Hide();
            label6.Hide();
            Details.Hide();

            var querry = "SELECT pacient_id, pacient_last_name, pacient_first_name, birthday" + " FROM Pacients " +
                "WHERE pacient_id IN(SELECT pacient_id from ASSOCIATIONS WHERE doctor_id =" + doctor.docID + ");";

            SqlConnectionStringBuilder builder = build();

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand(querry, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (int)reader["pacient_id"];
                        string patientLastName = (string)reader["pacient_last_name"];
                        string pacienFirstName = (string)reader["pacient_first_name"];
                        DateTime bday = (DateTime)reader["birthday"];

                        Patient patient = new Patient(id, patientLastName, pacienFirstName, bday);
                        doctor.patients.Add(patient);
                    }
                }
            }
            DisplayPacients();
        }

        private void tbPIN_Click(object sender, EventArgs e)
        {
            tbPIN.Text = ""; 
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            if (successfulAuthentication > 5)
                logger.Warn("The doctor with ID {0} is repeatedly trying to input the PIN code {1}.", doctor.docID, tbPIN.Text.Trim().ToString());
            else
            {
                try
                {
                    int patientPIN = int.Parse(tbPIN.Text.Trim().ToString());
                    string hashedPIN = computeHash2(patientPIN.ToString());
                    SqlConnectionStringBuilder builder = build();
                    ListViewItem item = (ListViewItem)lvPacients.SelectedItems[0];
                    Patient patient = (Patient)item.Tag;
                    string id = null;
                    using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                    {
                        var querry = "SELECT hashed_pin FROM Pacients WHERE pacient_id = " + patient.patientID + ";";
                        conn.Open();
                        var command = new SqlCommand(querry, conn);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = (string)reader["hashed_pin"];
                            }
                        }
                    }
                    if (hashedPIN.CompareTo(id) == 0)
                    {
                        tbTitle.Show();
                        dtpDate.Show();
                        tbDetails.Show();
                        label5.Show();
                        Details.Show();
                        label6.Show();
                    }
                    else
                    {
                        successfulAuthentication++;
                        MessageBox.Show("Wrong PIN!");
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Please select a patient!");
                }
                catch (FormatException)
                {
                    successfulAuthentication++;
                    MessageBox.Show("Please input a PIN code.");
                }
            }
        }

        private void btnSelectPacient_Click(object sender, EventArgs e)
        {
            if (lvPacients.SelectedItems.Count > 0)
            {
                ListViewItem item = lvPacients.SelectedItems[0];
                Patient patient = (Patient)item.Tag;

                SqlConnectionStringBuilder builder = build();

                var populateListBoxQuerry = "SELECT appointment_title, appointment_description, appointment_date FROM Block " +
                    "WHERE doctor_id = " + doctor.docID + "AND pacient_id = " + patient.patientID;

                using (SqlConnection populateListBoxConn = new SqlConnection(builder.ConnectionString))
                {
                    populateListBoxConn.Open();
                    var command = new SqlCommand(populateListBoxQuerry, populateListBoxConn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = (string)reader["appointment_title"];
                            string description = (string)reader["appointment_description"];
                            DateTime date = (DateTime)reader["appointment_date"];
                            MedicalRecord record = new MedicalRecord(doctor.docID, patient.patientID, title, description, date);
                            lbRecords.Items.Add(record);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a patient!");
            }
        }
    
        private int generateIndex(SqlConnectionStringBuilder builder)
        {
            var querryString = "SELECT CAST(NEXT VALUE FOR block_indexes AS INT) val;";
            int x = 0;
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();

                var command = new SqlCommand(querryString, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        x = (int)(reader["val"]);
                    }
                }
            }
            return x;
        }

        private int getIndex(SqlConnectionStringBuilder builder)
        {
            var querryString = "SELECT CAST(current_value as INT) current_value FROM sys.sequences WHERE name = 'block_indexes';";
            int x = 0;
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                
                var command = new SqlCommand(querryString, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        x = (int)(reader["current_value"]);
                    }
                }
            }
            return x;
        }

        private void proofOfWork(Hash hash, int difficulty)
        {
            var leadingZeros = new string('0', difficulty);

            while(hash.theHash.Substring(0, difficulty) != leadingZeros)
            {
                hash.nounce++;
                hash.theHash = hash.computeHash();
            }

        }

        private string getLastBlockHash()
        {
            SqlConnectionStringBuilder builder = build();
            string hash = null;

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                var querryString = "SELECT hash_of_curr_block FROM Block WHERE block_index+1 = (SELECT current_value FROM sys.sequences WHERE name = 'block_indexes');";
                using (SqlCommand command = new SqlCommand(querryString, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                            hash = (string)reader["hash_of_curr_block"];
                    }
                }
            }
            return hash;
        }

        private bool validateRecord()
        {
            if (tbDetails.Text.Trim().ToString().Length < 1)
            {
                MessageBox.Show("Please input the details of the appointment!");
                return false;
            }
            if (tbTitle.Text.Trim().ToString().Length < 1)
            {
                MessageBox.Show("Please input the type of the appointment!");
                return false;
            }
            if (dtpDate.Value > DateTime.Now)
            {
                MessageBox.Show("The date is invalid!");
                return false;
            }
            return true;
        }

        private void clearControls()
        {
            tbPIN.Text = null;
            tbDetails.Text = null;
            tbTitle.Text = null;
            dtpDate.Value = DateTime.Now;
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            if (validateRecord() == true)
            {
                try
                {
                    DateTime dateTime = dtpDate.Value;
                    string date = dateTime.ToString("yyyy-MM-dd");
                    string title = tbTitle.Text.Trim().ToString();
                    string details = tbDetails.Text.Trim().ToString();
                    int index;

                    ListViewItem item = lvPacients.SelectedItems[0];
                    Patient patient = (Patient)item.Tag;
                    long patientID = patient.patientID;


                    SqlConnectionStringBuilder builder = build();

                    using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                    {
                        var querryString =
                            "INSERT INTO Block (pacient_id, doctor_id, appointment_date, appointment_title, appointment_description, nounce, block_timestamp, block_index, " +
                            "hash_of_prev_block, hash_of_curr_block)" +
                            "VALUES (@pacID, @docID, @date, @title, @description, @nounce, @dateNow, @index, @hashOfPrevBlock, @hashOfCurrBlock);";
                        using (SqlCommand command = new SqlCommand(querryString, conn))
                        {
                            conn.Open();
                            command.Parameters.AddWithValue("@pacID", patientID);
                            command.Parameters.AddWithValue("@docID", doctor.docID);
                            command.Parameters.AddWithValue("@date", date);
                            command.Parameters.AddWithValue("@title", title);
                            command.Parameters.AddWithValue("@index", generateIndex(builder));
                            command.Parameters.AddWithValue("@description", details);
                            string now = DateTime.Now.ToString("yyyy-MM-dd");
                            command.Parameters.AddWithValue("@dateNow", DateTime.Now.ToString("yyyy-MM-dd"));
                            string theHashOfPrevBlock = getLastBlockHash();
                            command.Parameters.AddWithValue("@hashOfPrevBlock", theHashOfPrevBlock);

                            index = getIndex(builder);

                            //compute hash of current block;
                            string toHash = patientID + doctor.docID + date + title + details + now + index + theHashOfPrevBlock;
                            int nounce = 0;
                            Hash hash = new Hash(nounce, toHash);
                            proofOfWork(hash, 1);
                            command.Parameters.AddWithValue("@nounce", hash.nounce);
                            command.Parameters.AddWithValue("@hashOfCurrBlock", hash.computeHash());

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                                }
                            }
                        }
                    }
                    Logger logger = LogManager.GetCurrentClassLogger();
                    logger.Debug("Doctor {0} added a record for patient {1}.", doctor.docID, patientID);
                    MedicalRecord record = new MedicalRecord(doctor.docID, patientID, title, details, dateTime);
                    clearControls();
                    lbRecords.Items.Add(record);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Please select a patient!");
                }
            }
        }

        private void selectRecord_Click(object sender, EventArgs e)
        {
            MedicalRecord record = (MedicalRecord)lbRecords.SelectedItem;
            ListViewItem item = (ListViewItem)lvPacients.SelectedItems[0];
            Patient patient = (Patient)item.Tag;
            MedicalRecordInterface medicalRecordInterface = new MedicalRecordInterface(record, patient);
            medicalRecordInterface.ShowDialog();
        }

        private void tbPIN_Validating(object sender, CancelEventArgs e)
        {
            if (!(tbPIN.Text.Trim().All(char.IsNumber)) || tbPIN.Text.Trim().Length != 4)
            {
                errorProvider.SetError(tbPIN, "You did not input a PIN code!");
                e.Cancel = true;
            }
        }

        private void tbPIN_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbPIN, null);
        }

        private void tbNewPacientID_Validating(object sender, CancelEventArgs e)
        {
            if (tbNewPacientID.Text.Trim().Length != 7)
            {
                errorProvider.SetError(tbNewPacientID, "Wrong ID.");
                e.Cancel = true;
            }
        }

        private void tbNewPacientID_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbNewPacientID, null);
        }

        private void lvPacients_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbRecords.Items.Clear();
            if (lvPacients.SelectedItems.Count > 0)
            {
                ListViewItem item = lvPacients.SelectedItems[0];
                Patient patient = (Patient)item.Tag;

                //select all the records in the listbox
                SqlConnectionStringBuilder builder = build();

                var populateListBoxQuerry = "SELECT appointment_title, appointment_description, appointment_date FROM Block " +
                    "WHERE doctor_id = " + doctor.docID + "AND pacient_id = " + patient.patientID;

                using (SqlConnection populateListBoxConn = new SqlConnection(builder.ConnectionString))
                {
                    populateListBoxConn.Open();
                    var command = new SqlCommand(populateListBoxQuerry, populateListBoxConn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = (string)reader["appointment_title"];
                            string description = (string)reader["appointment_description"];
                            DateTime date = (DateTime)reader["appointment_date"];
                            MedicalRecord record = new MedicalRecord(doctor.docID, patient.patientID, title, description, date);
                            lbRecords.Items.Add(record);
                        }
                    }
                }
            }
        }

        private void btnDones_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
