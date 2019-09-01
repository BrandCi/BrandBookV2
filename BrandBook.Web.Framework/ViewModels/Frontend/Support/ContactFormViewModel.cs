using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Resources;

namespace BrandBook.Web.Framework.ViewModels.Frontend.Support
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
