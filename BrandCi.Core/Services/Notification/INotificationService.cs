using BrandCi.Core.ViewModels.Notification;

namespace BrandCi.Core.Services.Notification
{
    public interface INotificationService
    {
        bool SendNotification(EmailTemplateViewModel model);
        bool IsEmailValid(string email);
        bool ContentContainsSpamIdentificationKeywords(string inputString);
    }
}
