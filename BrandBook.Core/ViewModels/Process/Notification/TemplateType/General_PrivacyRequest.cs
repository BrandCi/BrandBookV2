using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.ViewModels.Process.Notification.TemplateType
{
    // ReSharper disable once InconsistentNaming
    public class General_PrivacyRequest
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string RequestType { get; set; }
        public string Message { get; set; }
        public string RequestDate { get; set; }
        public string RequestIp { get; set; }
    }
}
