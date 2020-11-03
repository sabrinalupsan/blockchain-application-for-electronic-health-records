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
    public partial class ProfileSelect : Form
    {
        public ProfileSelect()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            DoctorLogIn doctorLogin = new DoctorLogIn();
            doctorLogin.Show();
        }

        private void btnPacient_Click(object sender, EventArgs e)
        {
            PacientLogIn pacientLogin = new PacientLogIn();
            pacientLogin.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
        }

    }
}
