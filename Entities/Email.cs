using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Email
    {
        private NetworkCredential login;
        private SmtpClient client;
        private MailMessage msg;

        private int Port = 587;
        private bool SSL = true;
        private string Smtp = "smtp.gmail.com";
        private string Username;
        private string Password;

        public Email(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public bool send(string to, string cc, string subject, string message)
        {
            try
            {
                login = new NetworkCredential(this.Username, this.Password);
                client = new SmtpClient(this.Smtp);
                client.Port = Convert.ToInt32(this.Port);
                client.EnableSsl = this.SSL;
                client.Credentials = login;
                msg = new MailMessage { From = new MailAddress(this.Username + this.Smtp, "", Encoding.UTF8) };
                msg.To.Add(new MailAddress(to));
                if (!string.IsNullOrEmpty(cc))
                    msg.To.Add(new MailAddress(cc));
                msg.Subject = subject;
                msg.Body = message;
                msg.BodyEncoding = Encoding.UTF8;
                //msg.Attachments.Add(new Attachment(path));
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.Normal;
                msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.Send(msg);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
