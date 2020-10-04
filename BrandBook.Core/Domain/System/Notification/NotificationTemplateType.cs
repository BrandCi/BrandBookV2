// ReSharper disable InconsistentNaming
namespace BrandBook.Core.Domain.System.Notification
{
    public enum NotificationTemplateType
    {
        Plain,
        Admin_AccountCreationInformation,
        User_AccountVerification,
        User_AccountVerificationConfirmation,
        User_AccountForgotPassword,
        User_AccountForgotPasswordConfirmation,
        General_ContactRequest,
        General_PrivacyRequest,
        General_RequestClosedBeta
    }
}
