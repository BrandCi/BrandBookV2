using System.ComponentModel.DataAnnotations;

namespace BrandBook.Web.Framework.ViewModels.Auth.External
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
