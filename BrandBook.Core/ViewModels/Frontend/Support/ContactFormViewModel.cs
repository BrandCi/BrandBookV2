using BrandBook.Resources;
using System.ComponentModel.DataAnnotations;

namespace BrandBook.Core.ViewModels.Frontend.Support
{
    public class ContactFormViewModel
    {
        [Display(Name = "frontend_contact_input_name", ResourceType = typeof(Translations))]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "frontend_contact_input_email", ResourceType = typeof(Translations))]
        public string Email { get; set; }

        [Display(Name = "frontend_contact_input_subject", ResourceType = typeof(Translations))]
        public string Subject { get; set; }

        [Display(Name = "frontend_contact_input_message", ResourceType = typeof(Translations))]
        public string Message { get; set; }

        [Range(typeof(bool), "true", "true")]
        [Display(Name = "frontend_contact_input_privacypolicy", ResourceType = typeof(Translations))]
        public bool PrivacyPolicy { get; set; }

    }
}
