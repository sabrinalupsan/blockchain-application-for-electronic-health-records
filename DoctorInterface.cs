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
using System.Data.SqlClient;

namespace BlockchainApp
{
    public partial class DoctorInterface : Form
    {
        Doctor doctor;

        public DoctorInterface(Doctor doctor)
        {
            InitializeComponent();
            this.doctor = doctor;
            doctor.pacients = new List<Pacient>();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "blockchainapp.database.windows.net";
            builder.UserID = "lupsansabrina18";
            builder.Password = "Selenacolierul9!";
            builder.InitialCatalog = "blockchainapp";

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
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "blockchainapp.database.windows.net";
            builder.UserID = "lupsansabrina18";
            builder.Password = "Selenacolierul9!";
            builder.InitialCatalog = "blockchainapp";

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

        private void btnDone_Click(object sender, EventArgs e)
        {
            long pacientID = long.Parse(tbNewPacientID.Text.Trim());

            //input in the pacient database the docID, lastName, firstName, password
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "blockchainapp.database.windows.net";
            builder.UserID = "lupsansabrina18";
            builder.Password = "Selenacolierul9!";
            builder.InitialCatalog = "blockchainapp";

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {

                var querryString =
                    "INSERT INTO Associations (doctor_id, pacient_id)" +
                    "VALUES (@docID, @pacientID);";
                using (SqlCommand command = new SqlCommand(querryString, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@docID", doctor.docID);
                    command.Parameters.AddWithValue("@pacientID", pacientID.ToString());

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

        public void DisplayPacients()
        {
            lvPacients.Items.Clear();
            foreach (Pacient pacient in doctor.pacients)
            {
                var listViewItem = new ListViewItem(pacient.pacientID.ToString());
                listViewItem.SubItems.Add(pacient.lastName);
                listViewItem.SubItems.Add(pacient.firstName);
                listViewItem.Tag = pacient;
                lvPacients.Items.Add(listViewItem);
            }
            tbTitle.Hide();
        }

        private void DoctorInterface_Load(object sender, EventArgs e)
        {

            var querry = "SELECT pacient_id, pacient_last_name, pacient_first_name, birthday" + " FROM Pacients " +
                "WHERE pacient_id IN(SELECT pacient_id from ASSOCIATIONS WHERE doctor_id =" + doctor.docID + ");";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "blockchainapp.database.windows.net";
            builder.UserID = "lupsansabrina18";
            builder.Password = "Selenacolierul9!";
            builder.InitialCatalog = "blockchainapp";

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand(querry, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (int)reader["pacient_id"];
                        string pacientLastName = (string)reader["pacient_last_name"];
                        string pacienFirstName = (string)reader["pacient_first_name"];
                        DateTime bday = (DateTime)reader["birthday"];

                        Pacient pacient = new Pacient(id, pacientLastName, pacienFirstName, bday);
                        doctor.pacients.Add(pacient);
                    }
                }
            }
            tbTitle.Hide();
            tbDetails.Hide();
            dtpDate.Hide();
            label5.Hide();
            label6.Hide();
            Details.Hide();
            DisplayPacients();
        }

        private void tbPIN_Click(object sender, EventArgs e)
        {
            tbPIN.Text = ""; 
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //get the PIN from the database
            //check it with tbPIN.Text.Trim().ToString();
            //if PIN ok:
            tbTitle.Show();
            dtpDate.Show();
            tbDetails.Show();
            label5.Show();
            label6.Show();
            Details.Show();
        }

        private void btnSelectPacient_Click(object sender, EventArgs e)
        {
            //get the pacient ID from the listview
            //select all the records in the listbox
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
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "blockchainapp.database.windows.net";
            builder.UserID = "lupsansabrina18";
            builder.Password = "Selenacolierul9!";
            builder.InitialCatalog = "blockchainapp";
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

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {

            try
            { 
                DateTime dateTime = dtpDate.Value;
                string date = dateTime.ToString("yyyy-MM-dd");
                string title = tbTitle.Text.Trim().ToString();
                string details = tbDetails.Text.Trim().ToString();
                int index;

                ListViewItem item = (ListViewItem)lvPacients.SelectedItems[0];
                Pacient pacient = (Pacient)item.Tag;
                long pacientID = pacient.pacientID;
            

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "blockchainapp.database.windows.net";
                builder.UserID = "lupsansabrina18";
                builder.Password = "Selenacolierul9!";
                builder.InitialCatalog = "blockchainapp";

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                { 
                    var querryString =
                        "INSERT INTO Block (pacient_id, doctor_id, appointment_date, appointment_title, appointment_description, nounce, block_timestamp, block_index, " +
                        "hash_of_prev_block, hash_of_curr_block)" +
                        "VALUES (@pacID, @docID, @date, @title, @description, @nounce, @dateNow, @index, @hashOfPrevBlock, @hashOfCurrBlock);";
                    using (SqlCommand command = new SqlCommand(querryString, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("@pacID", pacientID);
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
                        string toHash = pacientID + doctor.docID + date + title + details + now + index + theHashOfPrevBlock;
                        int nounce = 0;
                        Hash hash = new Hash(nounce, toHash);
                        proofOfWork(hash, 0);
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
                //now put the MedicalRecord in the listbox
                MedicalRecord record = new MedicalRecord(doctor.docID, pacientID, title, details, dateTime);
                //add to lbRecords;
                lbRecords.Items.Add(record.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select a pacient!");
            }
        }
    }
}
