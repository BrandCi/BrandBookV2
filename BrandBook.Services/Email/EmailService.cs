﻿using log4net;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BrandBook.Services.Email
{
    [Obsolete("This Service is no longer supported! Use NotificationService instead.", false)]
    public class EmailService
    {

        protected static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        public static async Task<bool> SendEmailAsync(string body)
        {
            var isSent = false;

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
                    smtp.UseDefaultCredentials = false;

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
                Logger.Error(ex.Message, ex);
            }


            return isSent;
        }

    }
}
