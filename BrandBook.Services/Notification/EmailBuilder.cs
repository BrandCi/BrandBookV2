using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using BrandBook.Core.Services.Notification;

namespace BrandBook.Services.Notification
{
    public class EmailBuilder : IEmailBuilder
    {

        public string BuildEmail()
        {
            var emailContent = GetTemplate("User_AccountVerification.html");

            emailContent = emailContent.Replace("{{Subject}}", "Welcome to BrandCi");
            emailContent = emailContent.Replace("{{TargetUrl}}", "https://brandci.philipp-moser.de/Blog/Overview");

            return emailContent;

        }

        private static string GetTemplate(string emailName)
        {
            var templateFolder = HostingEnvironment.ApplicationPhysicalPath + "/Content/Email/";
            var templateFile = templateFolder  + emailName;

            return File.Exists(templateFile) ? File.ReadAllText(templateFile) : null;
        }

    }
}
