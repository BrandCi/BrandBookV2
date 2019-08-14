using System.ComponentModel.DataAnnotations;

namespace BrandBook.Web.Framework.ViewModels.App.Brand
{
    public class AddNewBrandViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public string ShortDescription { get; set; }

        [Required]
        public string MainColor { get; set; }

        public int ImageId { get; set; }

        [Display(Name = "Agree Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Please agree Terms and Conditions")]
        public bool AgreeTerms { get; set; }



    }
}
