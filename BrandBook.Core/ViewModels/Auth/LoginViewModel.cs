using BrandBook.Resources;
using System.ComponentModel.DataAnnotations;

namespace BrandBook.Core.ViewModels.Auth
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "auth_login_input_username", ResourceType = typeof(Translations))]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "auth_login_input_password", ResourceType = typeof(Translations))]
        public string Password { get; set; }

        [Display(Name = "auth_login_input_rememberme", ResourceType = typeof(Translations))]
        public bool RememberMe { get; set; }

    }
}
