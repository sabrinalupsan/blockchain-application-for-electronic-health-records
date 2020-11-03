using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class MedicalRecordInterface : MaterialForm
    {
        MedicalRecord record;
        Patient patient;

        public MedicalRecordInterface(MedicalRecord record, Patient patient)
        {
            InitializeComponent();
            this.record = record;
            this.patient = patient;
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Pink200, Primary.Pink300, Primary.LightBlue200, Accent.LightBlue100, TextShade.WHITE);
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
