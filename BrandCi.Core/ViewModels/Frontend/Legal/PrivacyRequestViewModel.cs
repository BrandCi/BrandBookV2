using System.ComponentModel.DataAnnotations;

namespace BrandCi.Core.ViewModels.Frontend.Legal
{
    public class PrivacyRequestViewModel
    {
        [Required]
        [Display(Name = "Request Type")]
        public string Type { get; set; }

        public string Message { get; set; }

        public string ReCaptchaToken { get; set; }

        public bool IsSent { get; set; }
    }
}
