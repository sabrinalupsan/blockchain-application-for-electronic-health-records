using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using NLog;
using Microsoft.Data.SqlClient;
using System.Net;

namespace BlockchainApp
{
    public partial class DoctorInterface : MaterialSkin.Controls.MaterialForm
    {
        private Doctor doctor;
        private List<Block> blocks = new List<Block>();
        private int successfulAuthentication = 0;
        private SqlConnectionStringBuilder builder;
        private Email email;

        public DoctorInterface(Doctor doctor)
        {
            InitializeComponent();
            this.doctor = doctor;
            doctor.patients = new List<Patient>();
            MySqlBuilder mySqlBuilder = MySqlBuilder.instance;
            email = Email.instance;
            builder = mySqlBuilder.builder;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                var querryString =
                    "SELECT * FROM BLOCK;";
                using (SqlCommand command = new SqlCommand(querryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                        if (!reader.HasRows)
                            GenesisBlock();
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

        private void GenesisBlock() {
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString)) {
                var querryString =
                    "INSERT INTO Block (patient_id, doctor_id, appointment_date, appointment_description, appointment_title, block_timestamp, block_index, " +
                    "hash_of_prev_block, hash_of_curr_block)" +
                    "VALUES (-1, -1, @date, 'no description', 'no title', @dateNow, 0, 0, @hashOfCurrBlock);";
                using (SqlCommand command = new SqlCommand(querryString, conn)) {
                    conn.Open();
                    string now = DateTime.Now.ToString("yyyy-MM-dd");
                    command.Parameters.AddWithValue("@date", now);
                    command.Parameters.AddWithValue("@dateNow", now);

                    string toHash = "-1" + "-1" + "1" + "no description" + "1" + "0" + "0";
                    command.Parameters.AddWithValue("@hashOfCurrBlock", computeHash2(toHash));

                    command.ExecuteNonQuery();
                }
            }
        }

        private bool checkID(long id)
        {
            bool ok = false;
            var querry = "SELECT patient_id from Patients;";
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand(querry, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int patient_id = (int)reader["patient_id"];
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
                    using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                    {
                        var querryString =
                            "INSERT INTO Associations (doctor_id, patient_id)" +
                            "VALUES (@docID, @patientID);";
                        using (SqlCommand command = new SqlCommand(querryString, conn))
                        {
                            conn.Open();
                            command.Parameters.AddWithValue("@docID", doctor.docID);
                            command.Parameters.AddWithValue("@patientID", patientID.ToString());

                            using (SqlDataReader reader = command.ExecuteReader())
                                while (reader.Read())
                                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                        }
                    }
                    updateListView();
                    Logger logger = LogManager.GetCurrentClassLogger();
                    logger.Debug("Doctor {0} added patient {1} to his list.", doctor.docID, patientID);
                    progressBar.Value = 100;
                    progressLabel.Text = "Patient added!";
                    tbNewPacientID.Clear();
                }
                else
                    MessageBox.Show("That ID does not correspond to any existing patient.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please input a valid patient ID!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("You already have that patient!");
            }
        }

        public void DisplayPatients()
        {
            lvPatients.Items.Clear();
            foreach (Patient patient in doctor.patients)
            {
                var listViewItem = new ListViewItem(patient.patientID.ToString());
                listViewItem.SubItems.Add(patient.lastName);
                listViewItem.SubItems.Add(patient.firstName);
                listViewItem.Tag = patient;
                lvPatients.Items.Add(listViewItem);
            }
            tbTitle.Hide();
        }

        private void updateListView()
        {
            var querry = "SELECT patient_id, patient_last_name, patient_first_name, birthday" + " FROM Patients " +
                "WHERE patient_id IN(SELECT patient_id from ASSOCIATIONS WHERE doctor_id =" + doctor.docID + ");";

            doctor.patients.Clear();

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand(querry, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (int)reader["patient_id"];
                        string patientLastName = (string)reader["patient_last_name"];
                        string patientFirstName = (string)reader["patient_first_name"];
                        DateTime bday = (DateTime)reader["birthday"];

                        Patient patient = new Patient(id, patientLastName, patientFirstName, bday);
                        doctor.patients.Add(patient);
                    }
                }
            }
            DisplayPatients();
        }

        private void hideControls()
        {
            tbPIN.Enabled = true;
            btnCheck.Enabled = true;
            tbPIN.Clear();
            tbTitle.Hide();
            tbDetails.Hide();
            dtpDate.Hide();
            label5.Hide();
            label6.Hide();
            Details.Hide();
            //lbRecords.Visible = false;
        }

        private void showControls()
        {
            lbRecords.Visible = true;
            tbTitle.Show();
            dtpDate.Show();
            tbDetails.Show();
            label5.Show();
            Details.Show();
            label6.Show();
        }

        private string getIP()
        {
            string hostName = Dns.GetHostName();
            return Dns.GetHostByName(hostName).AddressList[0].ToString();
        }

        private void DoctorInterface_Load(object sender, EventArgs e)
        {
            string myIP = getIP();
            readLog(myIP);
            hideControls();

            var querry = "SELECT patient_id, patient_last_name, patient_first_name, birthday" + " FROM Patients " +
                "WHERE patient_id IN(SELECT patient_id from ASSOCIATIONS WHERE doctor_id =" + doctor.docID + ");";

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand(querry, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (int)reader["patient_id"];
                        string patientLastName = (string)reader["patient_last_name"];
                        string patientFirstName = (string)reader["patient_first_name"];
                        DateTime bday = (DateTime)reader["birthday"];

                        Patient patient = new Patient(id, patientLastName, patientFirstName, bday);
                        doctor.patients.Add(patient);
                    }
                }
            }
            DisplayPatients();
        }

        private void readLog(string ip)
        {
            string[] lines = System.IO.File.ReadAllLines("log.txt");
            int j = lines.Length - 1;
            for (int i = j; i >= 0; i--)
            {
                string substring = lines[i].Substring(24, (lines[i].Length - 24));
                string toCompare =
                    "|WARN|BlockchainApp.DoctorInterface|The doctor with ID 4583018 and IP 26.235.128.98 is repeatedly trying to input the PIN code 1234. " + ip + " is repeatedly trying to log in.";
                //de scris expresii regulate cu Cosmin
                if (substring.CompareTo(toCompare) == 0)
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

        private void tbPIN_Click(object sender, EventArgs e)
        {
            tbPIN.Text = "";
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvPatients.SelectedItems[0];
            Patient patient = new Patient(-1, "", "", DateTime.Now);
            if(item!=null)
                patient = (Patient)item.Tag;
            Logger logger = LogManager.GetCurrentClassLogger();
            if (successfulAuthentication > 5)
            {
                string myIP = getIP();
                logger.Warn("The doctor with ID {0} and IP {1} is repeatedly trying to input the PIN code {2}.", doctor.docID, myIP, tbPIN.Text.Trim().ToString()); 
                email.Send("hospichain@gmail.com", "Too many new record input attempts", "The doctor with the ID: " + 
                    doctor.docID + "and IP: "+ myIP+" is repeatedly trying to input a new PIN code for the patient with the ID: "+patient.patientID);
                MessageBox.Show("Invalid PIN and too many attempts! You need to wait 30 seconds.");
                Wait(30);
            }
            else
            {
                try
                {
                    int patientPIN = int.Parse(tbPIN.Text.Trim().ToString());
                    string hashedPIN = computeHash2(patientPIN.ToString());
                    string id = null;
                    using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                    {
                        var querry = "SELECT hashed_pin FROM Patients WHERE patient_id = " + patient.patientID + ";";
                        conn.Open();
                        var command = new SqlCommand(querry, conn);
                        using (SqlDataReader reader = command.ExecuteReader())
                            while (reader.Read())
                                id = (string)reader["hashed_pin"];
                    }
                    if (hashedPIN.CompareTo(id) == 0)
                    {
                        showControls();
                        tbPIN.Enabled = false;
                        btnCheck.Enabled = false;
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
                catch (InvalidCastException)
                {
                    MessageBox.Show("That patient does not have a PIN code yet. Please contact de administrator or inform them to log in first.");
                }
            }
        }

        private void Wait(double seconds)
        {
            tbPIN.Enabled = false;
            tbTitle.Enabled = false;
            tbDetails.Enabled = false;
            dtpDate.Enabled = false;
            tbNewPacientID.Enabled = false;
            lbRecords.Enabled = false;
            lvPatients.Enabled = false;
            btnAddNewRecord.Enabled = false;
            btnCheck.Enabled = false;
            btnDone.Enabled = false;
            btnAddNewRecord.Enabled = false;
            System.Threading.Thread.Sleep(1000 * (int)seconds);
            tbPIN.Enabled = true;
            tbTitle.Enabled = true;
            tbDetails.Enabled = true;
            dtpDate.Enabled = true;
            tbNewPacientID.Enabled = true;
            lbRecords.Enabled = true;
            lvPatients.Enabled = true;
            btnAddNewRecord.Enabled = true;
            btnCheck.Enabled = true;
            btnDone.Enabled = true;
            btnAddNewRecord.Enabled = true;
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
                    while (reader.Read())
                        x = (int)(reader["val"]);
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
                    while (reader.Read())
                        x = (int)(reader["current_value"]);
            }
            return x;
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

        private string getLastBlockHash()
        {
            string hash = null;

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                var querryString = "SELECT hash_of_curr_block FROM Block WHERE block_index+1 = (SELECT current_value FROM sys.sequences WHERE name = 'block_indexes');";
                using (SqlCommand command = new SqlCommand(querryString, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                            hash = (string)reader["hash_of_curr_block"];
                }
            }
            if (hash == null)
            {
                MessageBox.Show("An error occured. Please refer to the administrator."); //YOU NEED TO PUT A DROP SEQUENCE!
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
            //tbPIN.Text = null;
            tbDetails.Text = null;
            tbTitle.Text = null;
            dtpDate.Value = DateTime.Now;
        }

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
                    if (previousHash.CompareTo(hashedgenesisContent) != 0)
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

        private void logInsertRecord(long doctorID, long patientID)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Debug("Doctor {0} added a record for patient {1}.", doctorID, patientID);
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            bool isBlockchainValid = checkBlockchain();
            if (validateRecord() == true && isBlockchainValid==true)
            {
                try
                {
                    DateTime dateTime = dtpDate.Value;
                    string date = dateTime.ToString("yyyy-MM-dd");
                    string title = tbTitle.Text.Trim().ToString();
                    string details = tbDetails.Text.Trim().ToString();
                    int index;

                    ListViewItem item = lvPatients.SelectedItems[0];
                    Patient patient = (Patient)item.Tag;
                    long patientID = patient.patientID;
                    CheckRecord checkInterface = new CheckRecord(patient.lastName, patient.firstName, patient.patientID, title, details);
                    if (checkInterface.ShowDialog() == DialogResult.OK)
                    {
                        using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                        {
                            var querryString =
                                "INSERT INTO Block (patient_id, doctor_id, appointment_date, appointment_title, appointment_description, nounce, block_timestamp, block_index, " +
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

                                string toHash = patientID + doctor.docID + date + title + details + now + index + theHashOfPrevBlock;
                                int nounce = 0;
                                Hash hash = new Hash(nounce, toHash);
                                proofOfWork(hash, 1);
                                command.Parameters.AddWithValue("@nounce", hash.nounce);
                                command.Parameters.AddWithValue("@hashOfCurrBlock", hash.computeHash());

                                using (SqlDataReader reader = command.ExecuteReader())
                                    while (reader.Read())
                                        Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }

                        logInsertRecord(doctor.docID, patientID);
                        MedicalRecord record = new MedicalRecord(doctor.docID, patientID, title, details, dateTime);
                        progressBar.Value = 100;
                        progressLabel.Text = "Appointment added!";
                        clearControls();
                        lbRecords.Items.Add(record);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Please select a patient!");
                }
                catch (Microsoft.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    //fix the error => drop sequence and restart it from where you left (SELECT LAST BLOCK and get its index
                }
                
            }
            else {
                if(isBlockchainValid == false) {
                    try {
                        email.Send("lupsansabrina18@stud.ase.ro", "INVALID BLOCKCHAIN", "The blockchain was invalid. Immediate attention is required.");
                    }
                    catch(Exception) {
                        MessageBox.Show("Invalid blockchain.");
                    }
                }
            }
        }

        private void selectRecord_Click(object sender, EventArgs e)
        {
            MedicalRecord record = (MedicalRecord)lbRecords.SelectedItem;
            ListViewItem item = lvPatients.SelectedItems[0];
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

        private void lvPatients_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            lbRecords.Items.Clear();
            if (lvPatients.SelectedItems.Count > 0)
            {
                hideControls();
                ListViewItem item = lvPatients.SelectedItems[0];
                Patient patient = (Patient)item.Tag;

                var populateListBoxQuerry = "SELECT appointment_title, appointment_description, appointment_date FROM Block " +
                    "WHERE patient_id = " + patient.patientID + " AND doctor_id IN (SELECT doctor_id FROM Doctors" +
                    " WHERE specialization = '" + doctor.specialisation + "');";

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

        private void lbRecords_DoubleClick(object sender, EventArgs e)
        {
            MedicalRecord record = (MedicalRecord)lbRecords.SelectedItem;
            ListViewItem item = lvPatients.SelectedItems[0];
            Patient patient = (Patient)item.Tag;
            MedicalRecordInterface medicalRecordInterface = new MedicalRecordInterface(record, patient);
            medicalRecordInterface.ShowDialog();
        }

        private void lvPatients_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int column = e.Column;
            if(column == 0)
            {
                doctor.patients = doctor.patients.OrderBy(p => p.patientID).ToList();
            }
            else
                if(column == 1)
                {
                    doctor.patients = doctor.patients.OrderBy(p => p.lastName).ToList();
                }
                else
                {
                doctor.patients = doctor.patients.OrderBy(p => p.firstName).ToList();
            }
            DisplayPatients();
        }

        private void DoctorInterface_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressLabel.Text = "";
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressLabel.Text = "";
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressLabel.Text = "";
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressLabel.Text = "";
        }

        private void lvPatients_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressLabel.Text = "";
        }
    }
}
