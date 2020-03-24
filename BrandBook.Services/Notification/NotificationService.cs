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
        public IRestResponse SendNotification(string receiver, string subject, string content)
        {
            var apiBasicUrl = ConfigurationManager.AppSettings["MailgunApiBasicUrl"];
            var apiPrivateKey = ConfigurationManager.AppSettings["MailgunApiPrivateKey"];
            var siteName = ConfigurationManager.AppSettings["MailgunApiSiteName"];
            var sender = ConfigurationManager.AppSettings["MailgunApiSender"];


            var client = new RestClient
            {
                BaseUrl = new Uri(apiBasicUrl),
                Authenticator = new HttpBasicAuthenticator("api", apiPrivateKey)
            };

            var request = new RestRequest();

            request.AddParameter("domain", siteName, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";

            request.AddParameter("from", sender);
            request.AddParameter("to", receiver);
            request.AddParameter("subject", subject);
            request.AddParameter("text", content);

            request.Method = Method.POST;

            return client.Execute(request);
        }
    }
}
