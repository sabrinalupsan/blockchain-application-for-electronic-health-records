using MaterialSkin;
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
    public partial class ProfileSelect : MaterialSkin.Controls.MaterialForm
    {
        public ProfileSelect()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo300, Primary.Indigo400, Primary.Indigo500, Accent.Pink200, TextShade.WHITE);
            InitializeComponent();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            DoctorLogIn doctorLogin = new DoctorLogIn();
            doctorLogin.Show();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            PatientLogin patientLogin = new PatientLogin();
            patientLogin.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
        }

        private void forgotLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPassword reset = new ResetPassword();
            reset.ShowDialog();
        }
    }
}
