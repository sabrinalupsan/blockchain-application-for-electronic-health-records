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
    public partial class AdminLogin : Form
    {
        int successfulAuthentication = 0;

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
            Logger logger = LogManager.GetCurrentClassLogger();
            string password = tbPassword.Text.Trim().ToString();
            if (password.CompareTo("123") == 0)
            {
                AdminInterface form = new AdminInterface();
                Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Wrong password.");
                successfulAuthentication++;
            }
            if(successfulAuthentication>5)
            {
                logger.Warn("Someone is repeateldy trying to log into admin!");
            }
        }
    }
}
