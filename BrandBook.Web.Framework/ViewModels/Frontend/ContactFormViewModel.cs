using System.ComponentModel.DataAnnotations;

namespace BrandBook.Web.Framework.ViewModels.Frontend
{
    public class ContactFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Please accept Privacy Policy")]
        public bool AcceptPrivacyPolicy { get; set; }
    }
}
