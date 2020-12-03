using System.ComponentModel.DataAnnotations;

namespace BrandCi.Core.ViewModels.Frontend.Support
{
    public class ContactFormViewModel
    {
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        [Range(typeof(bool), "true", "true")]
        public bool PrivacyPolicy { get; set; }

        public string ReCaptchaToken { get; set; }

        public bool IsSent { get; set; }
    }
}
