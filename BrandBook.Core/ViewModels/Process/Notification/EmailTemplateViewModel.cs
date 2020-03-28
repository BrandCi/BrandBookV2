using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.ViewModels.Process.Notification.TemplateType;
// ReSharper disable InconsistentNaming

namespace BrandBook.Core.ViewModels.Process.Notification
{
    public class EmailTemplateViewModel
    {
        public EmailTemplateType Type { get; set; }
        public string Subject { get; set; }
        public string Receiver { get; set; }

        public User_AccountVerification User_AccountVerification { get; set; }
        public User_AccountVerificationConfirmation User_AccountVerificationConfirmation { get; set; }
        public General_ContactRequest General_ContactRequest { get; set; }
    }

    public enum EmailTemplateType
    {
        Plain,
        User_AccountVerification,
        User_AccountVerificationConfirmation,
        General_ContactRequest
    }
}
