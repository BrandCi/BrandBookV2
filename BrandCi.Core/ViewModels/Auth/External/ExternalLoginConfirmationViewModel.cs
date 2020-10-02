using System.ComponentModel.DataAnnotations;

namespace BrandBook.Core.ViewModels.Auth.External
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
