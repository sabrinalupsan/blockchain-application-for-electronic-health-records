using NLog;
using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace BlockchainApp
{
    public partial class AdminLogin : MaterialSkin.Controls.MaterialForm
    {
        int successfulAuthentication = 0;
        private Email email;

        public AdminLogin()
        {
            InitializeComponent();
            email = Email.instance;
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

        private void Wait(double seconds)
        {
            tbPassword.Enabled = false;
            System.Threading.Thread.Sleep(1000 * (int)seconds);
            tbPassword.Enabled = true;
        }

        private string getIP()
        {
            string hostName = Dns.GetHostName();
            return Dns.GetHostByName(hostName).AddressList[0].ToString();
        }

        private void readLog(string ip)
        {
            string[] lines = System.IO.File.ReadAllLines("log.txt");
            int j = lines.Length - 1;
            for (int i = j; i >= 0; i--)
            {
                string substring = lines[i].Substring(22, (lines[i].Length - 22));
                string toCompare = "|WARN|BlockchainApp.AdminLogin|Someone with IP " + ip + " is repeatedly trying to log in.";
                if (substring.CompareTo(toCompare) == 0)
                {
                    string timestamp = lines[i].Substring(0, 19);
                    DateTimeConverter converter = new DateTimeConverter();
                    DateTime date = (DateTime)converter.ConvertFromString(timestamp);
                    double secondsPassed = (DateTime.Now - date).TotalSeconds;
                    if (secondsPassed < 40)
                    {
                        double secondsLeft = 40 - secondsPassed;
                        Wait(secondsLeft);
                        break;
                    }
                }
            }
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            string password = tbPassword.Text.Trim().ToString();
            string saltedPassword = saltPassword(password);
            if (saltedPassword != null && saltedPassword.CompareTo("4gblockchainapplication2VYWtK?LVjT,@v") == 0)
            {
                AdminInterface form = new AdminInterface();
                Hide();
                form.Show();
            }
            else
            {
                if (saltedPassword == null)
                    MessageBox.Show("Please input a password.");
                else
                    MessageBox.Show("Wrong password.");
                successfulAuthentication++;
            }
            if(successfulAuthentication>4)
            {
                string myIP = getIP();
                MessageBox.Show("Invalid password and too many attempts! You need to wait 30 seconds to log in again.");
                logger.Warn("Someone with IP {0} is repeatedly trying to log in.", myIP);
                email.Send("lupsansabrina18@stud.ase.ro", "Too many log in attempts",
                    "Someone with the IP " + myIP +" is repeatedly trying to log in");
                Wait(30);
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            string myIP = getIP();
            readLog(myIP);
        }
    }
}
