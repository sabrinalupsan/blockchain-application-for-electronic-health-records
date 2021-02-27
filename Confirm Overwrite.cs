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
    public partial class Confirm_Overwrite : MaterialSkin.Controls.MaterialForm
    {
        int successfulAuthentication = 0;
        public bool success = false;

        public Confirm_Overwrite()
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

        private void OKbtn_Click_1(object sender, EventArgs e)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            string password = tbPassword.Text.Trim().ToString();
            string saltedPassword = saltPassword(password);
            if (saltedPassword!=null && saltedPassword.CompareTo("12blockchainapplication3") == 0 && tbYes.Text.ToString().CompareTo("yes") == 0)
            {
                success = true;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult = DialogResult.None;
                if(saltedPassword==null)
                    MessageBox.Show("You need to write the password.");
                else
                    if(saltedPassword.CompareTo("12blockchainapplication3") != 0)
                    {
                        MessageBox.Show("Wrong password.");
                    }
                    else
                        if(tbYes.Text.ToString().CompareTo("yes") != 0)
                        {
                            MessageBox.Show("Please type yes if you are sure you want to overwrite the database.");
                        }
                successfulAuthentication++;
            }
            if (successfulAuthentication > 5)
            {
                logger.Warn("Someone is repeateldy trying to corrupt the database!");
            }
        }

        private void CancelBtn_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
