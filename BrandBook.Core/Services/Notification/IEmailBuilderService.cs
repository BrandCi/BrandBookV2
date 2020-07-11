using BrandBook.Core.ViewModels.Notification;

namespace BrandBook.Core.Services.Notification
{
    public interface IEmailBuilderService
    {
        string BuildEmail(EmailTemplateViewModel model);
    }
}
