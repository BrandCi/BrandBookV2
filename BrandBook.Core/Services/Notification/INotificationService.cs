using BrandBook.Core.ViewModels.Notification;

namespace BrandBook.Core.Services.Messaging
{
    public interface INotificationService
    {
        bool SendNotification(EmailTemplateViewModel model);
    }
}
