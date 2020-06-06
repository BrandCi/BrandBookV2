using BrandBook.Core.ViewModels.Notification;

namespace BrandBook.Core.Services.Notification
{
    public interface IEmailBuilder
    {
        string BuildEmail(EmailTemplateViewModel model);
    }
}
