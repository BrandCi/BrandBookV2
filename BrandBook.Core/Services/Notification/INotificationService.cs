using BrandBook.Core.ViewModels.Notification;

namespace BrandBook.Core.Services.Notification
{
    public interface INotificationService
    {
        bool SendNotification(EmailTemplateViewModel model);
        bool IsEmailValid(string email);
        bool ContentContainsSpamIdentificationKeywords(string inputString);
    }
}
