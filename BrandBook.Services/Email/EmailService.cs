using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Services.Email
{
    public class EmailService
    {

        public static async Task<bool> SendEmailAsync(string body)
        {
            bool isSent = false;

            try
            {
                var message = new MailMessage();


                // Email Settings
                message.To.Add(new MailAddress(ConfigurationManager.AppSettings["EmailReceiver"]));
                message.From = new MailAddress(ConfigurationManager.AppSettings["EmailAccount"]);
                message.Subject = ConfigurationManager.AppSettings["EmailSubjectDefault"];

                message.Body = body;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential()
                    {
                        UserName = ConfigurationManager.AppSettings["EmailAccount"],
                        Password = ConfigurationManager.AppSettings["EmailPassword"]
                    };


                    // Smtp Settings
                    smtp.Credentials = credential;
                    smtp.Host = ConfigurationManager.AppSettings["EmailSmtpHost"];
                    smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["EmailSmtpPort"]);
                    smtp.EnableSsl = true;



                    // Send Email
                    await smtp.SendMailAsync(message);
                    isSent = true;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return isSent;
        }

    }
}
