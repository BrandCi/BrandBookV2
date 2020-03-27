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
        private string _emailFolderPath = HostingEnvironment.ApplicationPhysicalPath + "/Content/Email";


        public string BuildEmail(string emailName)
        {
            var emailContent = GetTemplate(emailName + ".html");

            emailContent = emailContent.Replace("{{StylesPath}}", _emailFolderPath + "/styles.css");

            switch (emailName)
            {
                case "User_AccountVerification":
                    emailContent = emailContent.Replace("{{Subject}}", "Welcome to BrandCi");
                    emailContent = emailContent.Replace("{{TargetUrl}}", "https://brandci.philipp-moser.de/Blog/Overview");
                    break;
                default:
                    return null;
            }

            

            return emailContent;

        }

        private string GetTemplate(string emailName)
        {
            var templateFile = _emailFolderPath + emailName;

            return File.Exists(templateFile) ? File.ReadAllText(templateFile) : null;
        }

    }
}
