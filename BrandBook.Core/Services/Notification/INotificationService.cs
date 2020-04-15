using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.ViewModels.Notification;

namespace BrandBook.Core.Services.Messaging
{
    public interface INotificationService
    {
        bool SendNotification(EmailTemplateViewModel model);
    }
}
