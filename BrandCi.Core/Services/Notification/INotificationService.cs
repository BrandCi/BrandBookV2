using BrandCi.Core.ViewModels.Notification;

namespace BrandCi.Core.Services.Messaging
{
    public interface INotificationService
    {
        bool SendNotification(EmailTemplateViewModel model);
    }
}
