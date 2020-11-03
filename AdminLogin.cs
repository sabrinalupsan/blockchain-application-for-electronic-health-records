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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            string password = tbPassword.Text.Trim().ToString();
            if (password.CompareTo("123") == 0)
            {
                AdminInterface form = new AdminInterface();
                form.Show();
            }
            else
                MessageBox.Show("Wrong password.");
        }
    }
}
