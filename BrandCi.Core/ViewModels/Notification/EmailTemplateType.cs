// ReSharper disable InconsistentNaming
namespace BrandCi.Core.ViewModels.Notification
{
    public enum EmailTemplateType
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
