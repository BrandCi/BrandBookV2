using BrandBook.Core.Services.Notification;
using BrandBook.Core.ViewModels.Notification;
using System.Configuration;
using System.IO;
using System.Web.Hosting;

namespace BrandBook.Services.Notification
{
    public class EmailBuilder : IEmailBuilder
    {
        private readonly string _localEmailFolderPath;
        private readonly string _publicEmailFolderPath;
        private readonly string _fileServerUrlWithKey;

        public EmailBuilder()
        {
            _localEmailFolderPath = HostingEnvironment.ApplicationPhysicalPath + "/Content/EmailTemplates";

            var settingService = new SettingService();
            _publicEmailFolderPath = settingService.GetSettingValueByKey("conf_system_baseisurl");

            _fileServerUrlWithKey = $"{ConfigurationManager.AppSettings["CdnServerUrl"]}/{ConfigurationManager.AppSettings["CdnServerKey"]}";
        }


        public string BuildEmail(EmailTemplateViewModel model)
        {
            var emailContent = GetTemplate(model.Type + ".html");

            if (emailContent == null)
            {
                return null;
            }

            emailContent = emailContent.Replace("{{ApplicationUrl}}", _publicEmailFolderPath);
            emailContent = emailContent.Replace("{{FileServerUrl}}", _fileServerUrlWithKey + "/Email");
            emailContent = emailContent.Replace("{{Title}}", model.Subject);

            switch (model.Type)
            {
                case EmailTemplateType.Admin_AccountCreationInformation:
                    if (model.Admin_AccountCreationInformation == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{Creationdate}}", model.Admin_AccountCreationInformation.Creationdate);
                    emailContent = emailContent.Replace("{{Username}}", model.Admin_AccountCreationInformation.Username);
                    emailContent = emailContent.Replace("{{Email}}", model.Admin_AccountCreationInformation.Email);
                    emailContent = emailContent.Replace("{{Promocode}}", model.Admin_AccountCreationInformation.Promocode);
                    emailContent = emailContent.Replace("{{RequestIp}}", model.Admin_AccountCreationInformation.RequestIp);
                    break;
                case EmailTemplateType.User_AccountVerification:
                    if (model.User_AccountVerification == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{Username}}", model.User_AccountVerification.Username);
                    emailContent = emailContent.Replace("{{EmailAddress}}", model.User_AccountVerification.EmailAddress);
                    emailContent = emailContent.Replace("{{TargetUrl}}", model.User_AccountVerification.TargetUrl);
                    break;
                case EmailTemplateType.General_ContactRequest:
                    if (model.General_ContactRequest == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{Subject}}", model.General_ContactRequest.Subject);
                    emailContent = emailContent.Replace("{{Name}}", model.General_ContactRequest.Name);
                    emailContent = emailContent.Replace("{{Email}}", model.General_ContactRequest.Email);
                    emailContent = emailContent.Replace("{{RequestIp}}", model.General_ContactRequest.RequestIp);
                    emailContent = emailContent.Replace("{{Message}}", model.General_ContactRequest.Message);
                    break;
                case EmailTemplateType.General_PrivacyRequest:
                    if (model.General_PrivacyRequest == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{UserId}}", model.General_PrivacyRequest.UserId.ToString());
                    emailContent = emailContent.Replace("{{Email}}", model.General_PrivacyRequest.Email);
                    emailContent = emailContent.Replace("{{RequestType}}", model.General_PrivacyRequest.RequestType);
                    emailContent = emailContent.Replace("{{Message}}", model.General_PrivacyRequest.Message);
                    emailContent = emailContent.Replace("{{RequestDate}}", model.General_PrivacyRequest.RequestDate);
                    emailContent = emailContent.Replace("{{RequestIp}}", model.General_PrivacyRequest.RequestIp);
                    break;
                case EmailTemplateType.User_AccountVerificationConfirmation:
                    if (model.User_AccountVerificationConfirmation == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{EmailAddress}}", model.User_AccountVerificationConfirmation.EmailAddress);
                    break;
                case EmailTemplateType.User_AccountForgotPassword:
                    if (model.User_AccountForgotPassword == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{TargetUrl}}", model.User_AccountForgotPassword.TargetUrl);
                    break;
                case EmailTemplateType.User_AccountForgotPasswordConfirmation:
                    if (model.User_AccountForgotPasswordConfirmation == null)
                    {
                        return null;
                    }

                    break;
                case EmailTemplateType.General_RequestClosedBeta:
                    if (model.General_RequestClosedBeta == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{Email}}", model.General_RequestClosedBeta.Email);
                    emailContent = emailContent.Replace("{{RequestDate}}", model.General_RequestClosedBeta.RequestDate);
                    break;
                case EmailTemplateType.Plain:
                default:
                    return null;
            }


            return emailContent;
        }


        private string GetTemplate(string emailName)
        {
            var templateFile = _localEmailFolderPath + "/" + emailName;

            return File.Exists(templateFile) ? File.ReadAllText(templateFile) : null;
        }

    }
}
