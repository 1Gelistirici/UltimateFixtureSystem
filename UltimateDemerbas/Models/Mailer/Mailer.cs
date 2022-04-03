using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Models.Mailer
{
    public class Mailer
    {

        private IConfiguration configuration;
        public Mailer(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        public string Password { get { return configuration.GetSection("EmailPassword").Value; } }
        public string SystemEmail { get { return configuration.GetSection("SystemEmail").Value; } }

        public bool Sendmail(Mail mail)
        {

            try
            {
                mail.Sender = mail.Sender == null ? SystemEmail : mail.Sender;

                MailMessage mailMessage = new MailMessage(mail.Sender, mail.To);
                mailMessage.Subject = mail.Subject;
                mailMessage.Body = mail.Body;
                mailMessage.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(mail.Sender, Password);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }

        }
    }
}
