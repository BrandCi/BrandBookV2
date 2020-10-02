using System.ComponentModel.DataAnnotations;
using BrandCi.Resources;

namespace BrandCi.Core.ViewModels.Frontend.Product
{
    public class ClosedBetaViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "frontend_contact_input_email", ResourceType = typeof(Translations))]
        public string Email { get; set; }

        [Range(typeof(bool), "true", "true")]
        [Display(Name = "frontend_contact_input_privacypolicy", ResourceType = typeof(Translations))]
        public bool PrivacyPolicy { get; set; }

        public string ReCaptchaToken { get; set; }

        public bool IsSent { get; set; }
    }
}
