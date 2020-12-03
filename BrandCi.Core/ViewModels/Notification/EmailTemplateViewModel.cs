using BrandCi.Core.Domain.System.Notification;
using BrandCi.Core.ViewModels.Notification.TemplateType;

// ReSharper disable InconsistentNaming

namespace BrandCi.Core.ViewModels.Notification
{
    public class EmailTemplateViewModel
    {
        public NotificationTemplateType Type { get; set; }
        public string Subject { get; set; }
        public string Receiver { get; set; }
        public string CreationDate { get; set; }
        public string RequestIp { get; set; }

        public Admin_AccountCreationInformation Admin_AccountCreationInformation { get; set; }
        public User_AccountVerification User_AccountVerification { get; set; }
        public User_AccountVerificationConfirmation User_AccountVerificationConfirmation { get; set; }
        public User_AccountForgotPassword User_AccountForgotPassword { get; set; }
        public User_AccountForgotPasswordConfirmation User_AccountForgotPasswordConfirmation { get; set; }
        public General_ContactRequest General_ContactRequest { get; set; }
        public General_PrivacyRequest General_PrivacyRequest { get; set; }
        public General_RequestClosedBeta General_RequestClosedBeta { get; set; }
    }
}