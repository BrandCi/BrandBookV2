﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.Services.Notification;
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


        public bool SendNotification(string receiver, string subject, string content)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(_apiBasicUrl),
                Authenticator = new HttpBasicAuthenticator("api", _apiPrivateKey)
            };

            var emailContent = _emailBuilder.BuildEmail("User_AccountVerification");
            if (string.IsNullOrEmpty(emailContent))
            {
                return false;
            }

            var request = new RestRequest();

            request.AddParameter("domain", _siteName, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";

            request.AddParameter("from", _sender);
            request.AddParameter("to", receiver);
            request.AddParameter("subject", subject);
            request.AddParameter("html", emailContent);

            request.Method = Method.POST;


            var execution = client.Execute(request);

            if (execution.IsSuccessful)
            {
                Logger.Info("Notification {'to': '" + receiver + "'}, {'subject': '" + subject + "'}");

                return true;
            }
            else
            {
                Logger.Error("Notification: {" + execution.ErrorMessage + "}");

                return false;
            }
        }
    }
}
