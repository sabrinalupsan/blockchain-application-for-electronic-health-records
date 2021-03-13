using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class MedicalRecordInterface : MaterialSkin.Controls.MaterialForm
    {
        private MedicalRecord record;
        private Patient patient;
        private int charIndex;

        public MedicalRecordInterface(MedicalRecord record, Patient patient)
        {
            InitializeComponent();
            this.record = record;
            this.patient = patient;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MedicalRecordInterface_Load(object sender, EventArgs e)
        {
            try
            {
                tbLastName.Text = patient.lastName;
                tbFirstName.Text = patient.firstName;
                tbID.Text = record.patientID.ToString();
                tbTitle.Text = record.title;
                tbDescription.Text = record.description;
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show("Please select a patient");
                Close();
            }
        }

        private void btnPrintRecord_Click(object sender, EventArgs e)
        {

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
                        logger.Debug("The doctor with ID {0} just printed their record.", record.doctorID);
                    }
            }


        }

        private string stringToPrint(Patient patient, MedicalRecord record)
        {
            return patient.lastName + " " + patient.firstName + ", ID: " + patient.patientID + "\n" + record.title + "\n" + record.description;
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

            e.Graphics.MeasureString(stringToPrint(patient, record).Substring(charIndex), font, new SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt, out intCharsFitted, out intLinesFilled);

            e.Graphics.DrawString(stringToPrint(patient, record).Substring(charIndex), font, Brushes.Black, rectPrintingArea, fmt);

            charIndex += intCharsFitted;

            if (charIndex < record.description.Length)
                e.HasMorePages = true;
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            charIndex = 0;
        }
    }
}
