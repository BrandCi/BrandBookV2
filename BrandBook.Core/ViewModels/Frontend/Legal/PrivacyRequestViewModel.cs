using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Resources;

namespace BrandBook.Core.ViewModels.Frontend.Legal
{
    public class PrivacyRequestViewModel
    {
        [Required]
        [Display(Name = "Request Type")]
        public string Type { get; set; }

        [Display(Name = "frontend_legal_privacyrequest_input_message", ResourceType = typeof(Translations))]
        public string Message { get; set; }

        public string ReCaptchaToken { get; set; }

        public bool IsSent { get; set; }
    }
}
