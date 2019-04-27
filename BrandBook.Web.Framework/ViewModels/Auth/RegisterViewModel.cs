using System.ComponentModel.DataAnnotations;

namespace BrandBook.Web.Framework.ViewModels.Auth
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Nutzername")]
        public string Username { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Passwort wiederholen")]
        [Compare("Password", ErrorMessage = "Die Passwörter stimmen nicht überein")]
        public string ConfirmPassword { get; set; }

    }
}
