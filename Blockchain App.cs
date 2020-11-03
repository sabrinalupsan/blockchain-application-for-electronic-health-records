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
            DoctorLogIn docInterface = new DoctorLogIn();
            docInterface.Show();
        }

        private void btnPacient_Click(object sender, EventArgs e)
        {
            PacientLogIn pacientInterface = new PacientLogIn();
            pacientInterface.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLogin form = new AdminLogin();
            form.Show();
        }

    }
}
