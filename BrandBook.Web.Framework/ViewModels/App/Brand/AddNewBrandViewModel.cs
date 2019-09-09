using System.ComponentModel.DataAnnotations;
using BrandBook.Resources;

namespace BrandBook.Web.Framework.ViewModels.App.Brand
{
    public class AddNewBrandViewModel
    {
        [Required]
        [Display(Name = "app_brands_addbrand_name", ResourceType = typeof(Translations))]
        public string Name { get; set; }

        [Display(Name = "app_brands_addbrand_description", ResourceType = typeof(Translations))]
        public string Description { get; set; }

        [Display(Name = "app_brands_addbrand_shortdescription", ResourceType = typeof(Translations))]
        public string ShortDescription { get; set; }

        [Display(Name = "app_brands_addbrand_maincolor", ResourceType = typeof(Translations))]
        public string MainColor { get; set; }

        [Display(Name = "app_brands_addbrand_image", ResourceType = typeof(Translations))]
        public int ImageId { get; set; }

    }
}
