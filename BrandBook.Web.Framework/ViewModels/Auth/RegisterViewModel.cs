using System.ComponentModel.DataAnnotations;
using BrandBook.Resources;

namespace BrandBook.Web.Framework.ViewModels.Auth
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [Display(Name = "auth_register_input_email", ResourceType = typeof(Translations))]
        public string Email { get; set; }


        [Required]
        [Display(Name = "auth_register_input_username", ResourceType = typeof(Translations))]
        public string Username { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "auth_register_input_password", ResourceType = typeof(Translations))]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "auth_register_input_confirmpassword", ResourceType = typeof(Translations))]
        [Compare("Password", ErrorMessage = "Die Passwörter stimmen nicht überein")]
        public string ConfirmPassword { get; set; }

        
        [Range(typeof(bool), "true", "true", ErrorMessage = "Sie müssen die Datenschutzerklärung akzeptieren.")]
        [Display(Name = "Ich habe die Datenschutzerklärung gelesen und aktzeptiere diese.")]
        public bool PrivacyPolicyAccepted { get; set; }

    }
}
