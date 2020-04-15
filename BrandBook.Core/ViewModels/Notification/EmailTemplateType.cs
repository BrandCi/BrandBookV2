// ReSharper disable InconsistentNaming
namespace BrandBook.Core.ViewModels.Notification
{
    public enum EmailTemplateType
    {
        Plain,
        Admin_AccountCreationInformation,
        User_AccountVerification,
        User_AccountVerificationConfirmation,
        User_AccountForgotPassword,
        General_ContactRequest,
        General_PrivacyRequest
    }
}
