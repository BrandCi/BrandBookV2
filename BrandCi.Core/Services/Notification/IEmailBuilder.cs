using BrandCi.Core.ViewModels.Notification;

namespace BrandCi.Core.Services.Notification
{
    public interface IEmailBuilder
    {
        string BuildEmail(EmailTemplateViewModel model);
    }
}
