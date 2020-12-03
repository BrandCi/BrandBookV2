using System.ComponentModel.DataAnnotations;

namespace BrandCi.Core.ViewModels.Frontend.Product
{
    public class ClosedBetaViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(typeof(bool), "true", "true")]
        public bool PrivacyPolicy { get; set; }

        public string ReCaptchaToken { get; set; }

        public bool IsSent { get; set; }
    }
}
