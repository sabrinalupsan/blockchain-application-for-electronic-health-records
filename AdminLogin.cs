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

        private string saltPassword(string password)
        {
            string saltedPassword = null;
            for (int i = 0; i < password.Length; i++)
            {
                if (i == 2)
                    saltedPassword += "blockchainapplication";
                saltedPassword += password[i];
            }
            return saltedPassword;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            string password = tbPassword.Text.Trim().ToString();
            string saltedPassword = saltPassword(password);
            if (saltedPassword.CompareTo("12blockchainapplication3") == 0)
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
