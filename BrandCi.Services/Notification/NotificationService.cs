using BrandCi.Core;
using BrandCi.Core.Services.Notification;
using BrandCi.Core.ViewModels.Notification;
using BrandCi.Infrastructure;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrandCi.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailBuilder _emailBuilder;


        private readonly string _apiBasicUrl;
        private readonly string _apiPrivateKey;
        private readonly string _siteName;
        private readonly string _sender;

        private readonly string _spamFilterIdentificationKeywords;

        private readonly string _appEnvironment;


        public NotificationService(IUnitOfWork unitOfWork, IEmailBuilder emailBuilder)
        {
            _unitOfWork = unitOfWork;
            _emailBuilder = emailBuilder;

            // _apiBasicUrl = ConfigurationManager.AppSettings["MailgunApiBasicUrl"];
            // _apiPrivateKey = ConfigurationManager.AppSettings["MailgunApiPrivateKey"];
            // _siteName = ConfigurationManager.AppSettings["MailgunApiSiteName"];
            // _sender = ConfigurationManager.AppSettings["MailgunApiSender"];

            // _spamFilterIdentificationKeywords = ConfigurationManager.AppSettings["NotificationSpamFilterIdentificationKeywords"];

            // _appEnvironment = ConfigurationManager.AppSettings["Environment"];


            _apiBasicUrl = "";
            _apiPrivateKey = "";
            _siteName = "";
            _sender = "";

            _spamFilterIdentificationKeywords = "";

            _appEnvironment = "";
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


            if(ContentContainsSpamIdentificationKeywords(emailContent))
            {
                SaveNotification(model, emailContent, true, false, "Spam FilterIdentificationKeyword was detected in Notification Content");

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

                // Logger.Info("Notification {'receiver': '" + model.Receiver + "'}, {'subject': '" + model.Subject + "'}");

                return true;
            }


            SaveNotification(model, emailContent, false, false, execution.ErrorMessage);

            // Logger.Error("Notification: {" + execution.ErrorMessage + "}");

            return false;

        }


        #region Public Helper Methods
        public bool IsEmailValid(string email)
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


        public bool ContentContainsSpamIdentificationKeywords(string inputString)
        {
            List<string> spamFilterIdentificationKeywords = _spamFilterIdentificationKeywords.Split(',').ToList();
            inputString = inputString.ToLower();

            return spamFilterIdentificationKeywords.Any(keyword => inputString.Contains(keyword));
        }
        #endregion


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
                // TODO: Update Model
                // model.Receiver = ConfigurationManager.AppSettings["DefaultNotificationReceiver"];
                model.Receiver = "receiver@test-user.de";
            }
        }

        private void SetEmailSubject(EmailTemplateViewModel model)
        {
            if(string.IsNullOrEmpty(model.Subject))
            {
                model.Subject = "Notification from BrandCi";
            }    
        }
        #endregion
    }

}
