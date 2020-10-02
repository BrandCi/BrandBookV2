using BrandBook.Resources;
using System.ComponentModel.DataAnnotations;

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
