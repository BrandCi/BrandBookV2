using System.ComponentModel.DataAnnotations;

namespace BrandCi.Core.ViewModels.Auth
{
    public class LoginViewModel
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReCaptchaToken { get; set; }

    }
}
