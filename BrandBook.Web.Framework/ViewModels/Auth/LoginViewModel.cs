using System.ComponentModel.DataAnnotations;

namespace BrandBook.Web.Framework.ViewModels.Auth
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "Nutzername")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }

        [Display(Name = "Daten speichern")]
        public bool RememberMe { get; set; }

    }
}
