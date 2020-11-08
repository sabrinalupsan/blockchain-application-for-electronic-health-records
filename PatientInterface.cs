using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainApp
{
    public partial class PatientInterface : Form
    {
        Patient patient;
        List<MedicalRecord> records = new List<MedicalRecord>();

        public PatientInterface(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
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

        private void PatientInterface_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = build();
            var querry = "SELECT doctor_id, appointment_date, appointment_title, appointment_description FROM Block WHERE pacient_id = " + patient.patientID+";";
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand(querry, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (int)reader["doctor_id"];
                        DateTime bday = (DateTime)reader["appointment_date"];
                        string title = (string)reader["appointment_title"];
                        string description = (string)reader["appointment_description"];
                        MedicalRecord medicalRecord = new MedicalRecord(patient.patientID, id, title, description, bday);
                        records.Add(medicalRecord);
                    }
                }
            }
            DisplayRecords();
        }

        private string getDoctorsLastName(long id)
        {
            SqlConnectionStringBuilder builder = build();
            var querry = "SELECT doctor_last_name, doctor_first_name FROM Doctors WHERE doctor_id = " + id + ";";
            string lastName = null;
            string firstName = null;
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand(querry, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lastName = (string)reader["doctor_last_name"];
                        firstName = (string)reader["doctor_first_name"];
                    }
                }
            }
            return lastName + " " + firstName;
        }

        private void DisplayRecords()
        {
            lvRecords.Items.Clear();
            foreach (MedicalRecord record in records)
            {
                var listViewItem = new ListViewItem(record.title);
                listViewItem.SubItems.Add(getDoctorsLastName(record.doctorID));
                listViewItem.Tag = record;
                lvRecords.Items.Add(listViewItem);
            }
        }

        private void btnSeeRecord_Click(object sender, EventArgs e)
        {
            if (lvRecords.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvRecords.SelectedItems[0];
                MedicalRecord record = (MedicalRecord)lvi.Tag;

                tbDate.Text = record.date.ToShortDateString();
                tbDescription.Text = record.description;
                tbName.Text = getDoctorsLastName(record.doctorID);
                tbTitle.Text = record.title;
            }
            else
                MessageBox.Show("Please select a record!");
        }

        private void btnPrintRecord_Click(object sender, EventArgs e)
        {
            //log this
        }
    }
}
