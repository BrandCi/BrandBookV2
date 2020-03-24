using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Services.Messaging;
using RestSharp;
using RestSharp.Authenticators;

namespace BrandBook.Services.Notification
{
    public class NotificationService : INotificationService
    {
        public string _apiBasicUrl;
        public string _apiPrivateKey;
        public string _siteName;
        public string _sender;


        public NotificationService()
        {
            _apiBasicUrl = ConfigurationManager.AppSettings["MailgunApiBasicUrl"];
            _apiPrivateKey = ConfigurationManager.AppSettings["MailgunApiPrivateKey"];
            _siteName = ConfigurationManager.AppSettings["MailgunApiSiteName"];
            _sender = ConfigurationManager.AppSettings["MailgunApiSender"];
        }


        public IRestResponse SendNotification(string receiver, string subject, string content)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(_apiBasicUrl),
                Authenticator = new HttpBasicAuthenticator("api", _apiPrivateKey)
            };

            var request = new RestRequest();

            request.AddParameter("domain", _siteName, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";

            request.AddParameter("from", _sender);
            request.AddParameter("to", receiver);
            request.AddParameter("subject", subject);
            request.AddParameter("html", content);

            request.Method = Method.POST;

            return client.Execute(request);
        }
    }
}
