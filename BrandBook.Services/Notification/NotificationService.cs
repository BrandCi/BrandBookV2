using BrandBook.Core;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.Services.Notification;
using BrandBook.Core.ViewModels.Notification;
using BrandBook.Infrastructure;
using log4net;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Configuration;

namespace BrandBook.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailBuilder _emailBuilder;
        protected static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);


        private readonly string _apiBasicUrl;
        private readonly string _apiPrivateKey;
        private readonly string _siteName;
        private readonly string _sender;

        private readonly string _appEnvironment;


        public NotificationService()
        {
            _unitOfWork = new UnitOfWork();
            _emailBuilder = new EmailBuilder();

            _apiBasicUrl = ConfigurationManager.AppSettings["MailgunApiBasicUrl"];
            _apiPrivateKey = ConfigurationManager.AppSettings["MailgunApiPrivateKey"];
            _siteName = ConfigurationManager.AppSettings["MailgunApiSiteName"];
            _sender = ConfigurationManager.AppSettings["MailgunApiSender"];

            _appEnvironment = ConfigurationManager.AppSettings["Environment"];
        }


        public bool SendNotification(EmailTemplateViewModel model)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(_apiBasicUrl),
                Authenticator = new HttpBasicAuthenticator("api", _apiPrivateKey)
            };

            SetNotificationValues(model);

            var emailContent = _emailBuilder.BuildEmail(model);
            if (string.IsNullOrEmpty(emailContent))
            {
                SaveNotification(model, emailContent, false, false, "Email Content could not be created.");

                return false;
            }


            var request = new RestRequest();

            request.AddParameter("domain", _siteName, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";

            request.AddParameter("from", _sender);
            request.AddParameter("to", model.Receiver);
            request.AddParameter("subject", model.Subject);

            request.AddParameter("o:tag", _appEnvironment);
            request.AddParameter("o:tag", model.Type);

            request.AddParameter("html", emailContent);

            request.Method = Method.POST;


            var execution = client.Execute(request);

            if (execution.IsSuccessful)
            {
                SaveNotification(model, emailContent, isSpam: false, isSent: true);

                Logger.Info("Notification {'receiver': '" + model.Receiver + "'}, {'subject': '" + model.Subject + "'}");

                return true;
            }


            SaveNotification(model, emailContent, false, false, execution.ErrorMessage);

            Logger.Error("Notification: {" + execution.ErrorMessage + "}");

            return false;

        }


        #region Private Methods
        private void SetNotificationValues(EmailTemplateViewModel model)
        {
            SetEmailReceiver(model);
            SetEmailSubject(model);
        }

        /// <summary>
        /// Saves the notification in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="emailContent"></param>
        private void SaveNotification(EmailTemplateViewModel model, string emailContent, bool isSpam = false, bool isSent = false, string errorMessage = "")
        {
            var notificationModel = new Core.Domain.System.Notification.Notification()
            {
                NotificationTemplateType = model.Type,
                Subject = model.Subject,
                CreationDate = model.CreationDate,
                Recipient = model.Receiver,
                RequestIp = model.RequestIp,
                EmailContent = emailContent,
                IsSpam = isSpam,
                IsSent = isSent,
                ErrorMessage = errorMessage
            };

            _unitOfWork.NotificationRepository.Add(notificationModel);
            _unitOfWork.SaveChanges();
        }

        private void SetEmailReceiver(EmailTemplateViewModel model)
        {
            if (!IsEmailValid(model.Receiver))
            {
                model.Receiver = ConfigurationManager.AppSettings["DefaultNotificationReceiver"];
            }
        }

        private void SetEmailSubject(EmailTemplateViewModel model)
        {
            if(string.IsNullOrEmpty(model.Subject))
            {
                model.Subject = "Notification from BrandCi";
            }    
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


        private static bool ParseContentAndCheckForSpam()
        {
            return false;
        }
        #endregion
    }

}
