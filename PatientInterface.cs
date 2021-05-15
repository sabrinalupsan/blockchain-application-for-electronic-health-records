using Microsoft.Data.SqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainApp
{
    public partial class PatientInterface : MaterialSkin.Controls.MaterialForm
    {
        Patient patient;
        List<MedicalRecord> records = new List<MedicalRecord>();
        MedicalRecord selectedRecord;
        private SqlConnectionStringBuilder builder;
        private int charIndex;

        public PatientInterface(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
            MySqlBuilder mySqlBuilder = MySqlBuilder.instance;
            builder = mySqlBuilder.builder;
        }

        private void PatientInterface_Load(object sender, EventArgs e)
        {
            var querry = "SELECT doctor_id, appointment_date, appointment_title, appointment_description " +
                "FROM Block WHERE patient_id = " + patient.patientID + ";";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString)) {

                connection.Open();
                var command = new SqlCommand(querry, connection);
                using (SqlDataReader reader = command.ExecuteReader()) {

                    while (reader.Read()) {
                        int id = (int)reader["doctor_id"];
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

        private string stringToPrint(Patient patient, MedicalRecord record)
        {
            return patient.lastName + " " + patient.firstName + ", ID: " + patient.patientID + "\n" + record.title + "\n" + record.description;
        }

        private void btnPrintRecord_Click(object sender, EventArgs e)
        {
            if (lvRecords.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvRecords.SelectedItems[0];
                selectedRecord = (MedicalRecord)lvi.Tag;

                tbDate.Text = selectedRecord.date.ToShortDateString();
                tbDescription.Text = selectedRecord.description;
                tbName.Text = getDoctorsLastName(selectedRecord.doctorID);
                tbTitle.Text = selectedRecord.title;

                pageSetupDialog.PageSettings = printDocument.DefaultPageSettings;

                if (pageSetupDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.DefaultPageSettings = pageSetupDialog.PageSettings;
                    try
                    {
                        printPreviewDialog.ShowDialog();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An error occurred while trying to load the document for Print Preview. Make sure you currently have access to a printer. A printer must be connected and accessible for Print Preview to work.");
                    }
                    if (printPreviewDialog.DialogResult != DialogResult.Cancel)
                        if (printDialog.ShowDialog() == DialogResult.OK)
                        {
                            printDocument.Print();
                            Logger logger = LogManager.GetCurrentClassLogger();
                            logger.Debug("The patient with ID {0} just printed their record.", patient.patientID);
                        }
                }
            }
            else
                MessageBox.Show("Please select a record!");

            
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Microsoft Sans Serif", 24);

            var pageSettings = printDocument.DefaultPageSettings;

            var intPrintAreaHeight = pageSettings.PaperSize.Height - pageSettings.Margins.Top - pageSettings.Margins.Bottom;
            var intPrintAreaWidth = pageSettings.PaperSize.Width - pageSettings.Margins.Left - pageSettings.Margins.Right;

            var marginLeft = pageSettings.Margins.Left;
            var marginTop = pageSettings.Margins.Top;

            if (printDocument.DefaultPageSettings.Landscape)
            {
                var intTemp = intPrintAreaHeight;
                intPrintAreaHeight = intPrintAreaWidth;
                intPrintAreaWidth = intTemp;
            }

            RectangleF rectPrintingArea = new RectangleF(marginLeft, marginTop, intPrintAreaWidth, intPrintAreaHeight);

            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);

            int intLinesFilled;
            int intCharsFitted;

            e.Graphics.MeasureString(stringToPrint(patient, selectedRecord).Substring(charIndex), font, new SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt, out intCharsFitted, out intLinesFilled);

            e.Graphics.DrawString(stringToPrint(patient, selectedRecord).Substring(charIndex), font, Brushes.Black, rectPrintingArea, fmt);

            charIndex += intCharsFitted;

            if (charIndex < selectedRecord.description.Length)
                e.HasMorePages = true;
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            charIndex = 0;
        }

        private void lvRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRecords.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvRecords.SelectedItems[0];
                selectedRecord = (MedicalRecord)lvi.Tag;

                tbDate.Text = selectedRecord.date.ToShortDateString();
                tbDescription.Text = selectedRecord.description;
                tbName.Text = getDoctorsLastName(selectedRecord.doctorID);
                tbTitle.Text = selectedRecord.title;
            }
            
        }
    }
}
