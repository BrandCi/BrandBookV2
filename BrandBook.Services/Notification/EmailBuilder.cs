using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using BrandBook.Core.Services.Notification;
using BrandBook.Core.ViewModels.Process.Notification;

namespace BrandBook.Services.Notification
{
    public class EmailBuilder : IEmailBuilder
    {
        private readonly string _emailFolderPath = HostingEnvironment.ApplicationPhysicalPath + "/Content/Email";


        public string BuildEmail(EmailTemplateViewModel model)
        {
            var emailContent = GetTemplate(model.Type + ".html");
            emailContent = emailContent.Replace("{{StylesPath}}", _emailFolderPath + "/styles.css");
            emailContent = emailContent.Replace("{{Title}}", model.Subject);

            switch (model.Type)
            {
                case EmailTemplateType.User_AccountVerification:
                    if (model.User_AccountVerification == null) return null;

                    emailContent = emailContent.Replace("{{Username}}", model.User_AccountVerification.Username);
                    emailContent = emailContent.Replace("{{TargetUrl}}", model.User_AccountVerification.TargetUrl);
                    break;
                case EmailTemplateType.General_ContactRequest:
                    if (model.General_ContactRequest == null) return null;

                    emailContent = emailContent.Replace("{{Subject}}", model.General_ContactRequest.Subject);
                    emailContent = emailContent.Replace("{{Name}}", model.General_ContactRequest.Name);
                    emailContent = emailContent.Replace("{{Email}}", model.General_ContactRequest.Email);
                    emailContent = emailContent.Replace("{{Message}}", model.General_ContactRequest.Message);
                    break;
                case EmailTemplateType.Plain:
                default:
                    return null;
            }

            

            return emailContent;

        }

        private string GetTemplate(string emailName)
        {
            var templateFile = _emailFolderPath + "/" + emailName;

            return File.Exists(templateFile) ? File.ReadAllText(templateFile) : null;
        }

    }
}
