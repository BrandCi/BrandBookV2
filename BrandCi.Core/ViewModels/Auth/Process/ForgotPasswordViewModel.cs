using System.ComponentModel.DataAnnotations;

namespace BrandBook.Core.ViewModels.Auth.Process
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
    }
}
