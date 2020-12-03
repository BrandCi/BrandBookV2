using BrandCi.Core.Domain.System.Notification;
using BrandCi.Core.Services;
using BrandCi.Core.Services.Notification;
using BrandCi.Core.ViewModels.Notification;
using System.Configuration;
using System.IO;

namespace BrandCi.Services.Notification
{
    public class EmailBuilder : IEmailBuilder
    {
        private readonly string _localEmailFolderPath;
        private readonly string _publicEmailFolderPath;
        private readonly string _fileServerUrlWithKey;

        public EmailBuilder(ISettingService settingService)
        {
            // TODO: Update Model
            // _localEmailFolderPath = HostingEnvironment.ApplicationPhysicalPath + "/Content/EmailTemplates";
            _localEmailFolderPath = "PATH" + "/Content/EmailTemplates";

            _publicEmailFolderPath = settingService.GetSettingValueByKey("conf_system_baseisurl");

            // TODO: Update Model
            // _fileServerUrlWithKey = $"{ ConfigurationManager.AppSettings["CdnServerUrl"] }/{ ConfigurationManager.AppSettings["CdnServerKey"] }";
            _fileServerUrlWithKey = $"CDN_PATH/CDN_KEY";
        }


        public string BuildEmail(EmailTemplateViewModel model)
        {
            var emailContent = GetTemplate(model.Type + ".html");

            if (emailContent == null)
            {
                return null;
            }

            emailContent = emailContent.Replace("{{ApplicationUrl}}", _publicEmailFolderPath);
            emailContent = emailContent.Replace("{{FileServerUrl}}", _fileServerUrlWithKey + "/EmailData");
            emailContent = emailContent.Replace("{{Title}}", model.Subject);

            switch (model.Type)
            {
                case NotificationTemplateType.Admin_AccountCreationInformation:
                    if (model.Admin_AccountCreationInformation == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{Creationdate}}", model.CreationDate);
                    emailContent = emailContent.Replace("{{Username}}", model.Admin_AccountCreationInformation.Username);
                    emailContent = emailContent.Replace("{{Email}}", model.Admin_AccountCreationInformation.Email);
                    emailContent = emailContent.Replace("{{Promocode}}", model.Admin_AccountCreationInformation.Promocode);
                    emailContent = emailContent.Replace("{{RequestIp}}", model.RequestIp);
                    break;

                case NotificationTemplateType.User_AccountVerification:
                    if (model.User_AccountVerification == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{Username}}", model.User_AccountVerification.Username);
                    emailContent = emailContent.Replace("{{EmailAddress}}", model.User_AccountVerification.EmailAddress);
                    emailContent = emailContent.Replace("{{TargetUrl}}", model.User_AccountVerification.TargetUrl);
                    break;

                case NotificationTemplateType.General_ContactRequest:
                    if (model.General_ContactRequest == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{Subject}}", model.General_ContactRequest.Subject);
                    emailContent = emailContent.Replace("{{Name}}", model.General_ContactRequest.Name);
                    emailContent = emailContent.Replace("{{Email}}", model.General_ContactRequest.Email);
                    emailContent = emailContent.Replace("{{RequestIp}}", model.RequestIp);
                    emailContent = emailContent.Replace("{{Message}}", model.General_ContactRequest.Message);
                    break;

                case NotificationTemplateType.General_PrivacyRequest:
                    if (model.General_PrivacyRequest == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{UserId}}", model.General_PrivacyRequest.UserId.ToString());
                    emailContent = emailContent.Replace("{{Email}}", model.General_PrivacyRequest.Email);
                    emailContent = emailContent.Replace("{{RequestType}}", model.General_PrivacyRequest.RequestType);
                    emailContent = emailContent.Replace("{{Message}}", model.General_PrivacyRequest.Message);
                    emailContent = emailContent.Replace("{{RequestDate}}", model.CreationDate);
                    emailContent = emailContent.Replace("{{RequestIp}}", model.RequestIp);
                    break;

                case NotificationTemplateType.User_AccountVerificationConfirmation:
                    if (model.User_AccountVerificationConfirmation == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{EmailAddress}}", model.User_AccountVerificationConfirmation.EmailAddress);
                    break;
                case NotificationTemplateType.User_AccountForgotPassword:
                    if (model.User_AccountForgotPassword == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{TargetUrl}}", model.User_AccountForgotPassword.TargetUrl);
                    break;

                case NotificationTemplateType.User_AccountForgotPasswordConfirmation:
                    if (model.User_AccountForgotPasswordConfirmation == null)
                    {
                        return null;
                    }

                    break;

                case NotificationTemplateType.General_RequestClosedBeta:
                    if (model.General_RequestClosedBeta == null)
                    {
                        return null;
                    }

                    emailContent = emailContent.Replace("{{Email}}", model.General_RequestClosedBeta.Email);
                    emailContent = emailContent.Replace("{{RequestDate}}", model.CreationDate);
                    break;

                case NotificationTemplateType.Plain:
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
