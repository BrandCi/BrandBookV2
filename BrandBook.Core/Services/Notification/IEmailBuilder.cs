using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.ViewModels.Process.Notification;

namespace BrandBook.Core.Services.Notification
{
    public interface IEmailBuilder
    {
        string BuildEmail(EmailTemplateViewModel model);
    }
}
