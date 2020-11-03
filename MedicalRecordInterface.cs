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
    public partial class MedicalRecordInterface : Form
    {
        MedicalRecord record;
        Patient patient;

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
            tbLastName.Text = patient.lastName;
            tbFirstName.Text = patient.firstName;
            tbID.Text = record.pacientID.ToString();
            tbTitle.Text = record.title;
            tbDescription.Text = record.description;
        }
    }
}
