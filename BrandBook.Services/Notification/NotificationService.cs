using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.Services.Notification;
using BrandBook.Core.ViewModels.Process.Notification;
using log4net;
using RestSharp;
using RestSharp.Authenticators;

namespace BrandBook.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailBuilder _emailBuilder;
        protected static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);


        public string _apiBasicUrl;
        public string _apiPrivateKey;
        public string _siteName;
        public string _sender;


        public NotificationService()
        {
            _emailBuilder = new EmailBuilder();

            _apiBasicUrl = ConfigurationManager.AppSettings["MailgunApiBasicUrl"];
            _apiPrivateKey = ConfigurationManager.AppSettings["MailgunApiPrivateKey"];
            _siteName = ConfigurationManager.AppSettings["MailgunApiSiteName"];
            _sender = ConfigurationManager.AppSettings["MailgunApiSender"];
        }


        public bool SendNotification(EmailTemplateViewModel model)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(_apiBasicUrl),
                Authenticator = new HttpBasicAuthenticator("api", _apiPrivateKey)
            };

            var emailContent = _emailBuilder.BuildEmail(model);
            if (string.IsNullOrEmpty(emailContent))
            {
                return false;
            }

            var emailReceiver = GetEmailReceiver(model.Receiver);
            var emailSubject = GetEmailSubject(model.Subject);
            var request = new RestRequest();

            request.AddParameter("domain", _siteName, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";

            request.AddParameter("from", _sender);
            request.AddParameter("to", emailReceiver);
            request.AddParameter("subject", emailSubject);
            request.AddParameter("html", emailContent);

            request.Method = Method.POST;


            var execution = client.Execute(request);

            if (execution.IsSuccessful)
            {
                Logger.Info("Notification {'receiver': '" + emailReceiver + "'}, {'subject': '" + emailSubject + "'}, {'requestip': '" + HttpContext.Current.Request.UserHostAddress + "'}");

                return true;
            }
            else
            {
                Logger.Error("Notification: {" + execution.ErrorMessage + "}, {'requestip': '" + HttpContext.Current.Request.UserHostAddress + "'}");

                return false;
            }
        }


        #region Private Methods
        private string GetEmailReceiver(string email)
        {
            var receiver = ConfigurationManager.AppSettings["DefaultNotificationReceiver"];
            if (IsEmailValid(email))
            {
                receiver = email;
            }

            return receiver;
        }

        private static string GetEmailSubject(string subject)
        {
            return string.IsNullOrEmpty(subject) ? "Notification from BrandCi" : subject;
        }


        private static bool IsEmailValid(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }

}
