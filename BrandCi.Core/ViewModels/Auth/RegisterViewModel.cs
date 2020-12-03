using System.ComponentModel.DataAnnotations;

namespace BrandCi.Core.ViewModels.Auth
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Username { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Die Passwörter stimmen nicht überein")]
        public string ConfirmPassword { get; set; }


        [Range(typeof(bool), "true", "true")]
        public bool PrivacyPolicyAccepted { get; set; }

        [Required]
        [Display(Name = "Beta Accesscode")]
        public string PromotionCode { get; set; }

        public string ReCaptchaToken { get; set; }

    }
}
