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

        public async Task<bool> SendEmailAsync(string receiver, string body, string subject = "")
        {
            bool isSent = false;

            try
            {
                var message = new MailMessage();

                // Email Settings
                message.To.Add(new MailAddress(receiver));
                message.From = new MailAddress(ConfigurationSettings.AppSettings["EmailAccount"]);
                message.Body = body;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential()
                    {
                        UserName = ConfigurationSettings.AppSettings["EmailAccount"],
                        Password = ConfigurationSettings.AppSettings["EmailPassword"]
                    };


                    // Smtp Settings
                    smtp.Credentials = credential;
                    smtp.Host = ConfigurationSettings.AppSettings["EmailSmtpHost"];
                    smtp.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["EmailSmtpPort"]);
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
