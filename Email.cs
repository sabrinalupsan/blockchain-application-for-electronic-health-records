using System.Net.Mail;

namespace BlockchainApp
{
    public sealed class Email
    {
        private SmtpClient client;
        private MailMessage msg;
        private System.Net.NetworkCredential smtpCreds;
        private const string sourceEmailAddress = "hospichain@gmail.com";
        private const string sourceEmailPassword = "6bachelor!AABB#";

        private static Email Instance;
        public static Email instance {
            get {
                if (Instance == null)
                    Instance = new Email();
                return Instance;
            }
        }

        private Email()
        {
            client = new SmtpClient();
            msg = new MailMessage();
            smtpCreds = new System.Net.NetworkCredential(sourceEmailAddress, sourceEmailPassword);
            client.Host = "smtp.gmail.com";
            client.Port = 25;
            client.UseDefaultCredentials = false;
            client.Credentials = smtpCreds;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public void Send(string sendTo, string subject, string body)
        {
            //convert string to MailAdress
            MailAddress to = null;
            if (sendTo != null && sendTo.CompareTo("") != 0)
                to = new MailAddress(sendTo);
            else
                return;
            MailAddress from = new MailAddress(sourceEmailAddress);

            //set up message settings

            msg.Subject = subject;
            msg.Body = body;
            msg.From = from;
            msg.To.Add(to);

            client.Send(msg);
        }
    }
}
