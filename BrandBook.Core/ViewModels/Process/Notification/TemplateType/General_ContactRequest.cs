using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.ViewModels.Process.Notification.TemplateType
{
    // ReSharper disable once InconsistentNaming
    public class General_ContactRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string RequestIp { get; set; }
        public string Message { get; set; }
    }
}
