using System.ComponentModel.DataAnnotations;

namespace BrandBook.Web.Framework.ViewModels.App.Brand
{
    public class AddNewBrandViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public string MainColor { get; set; }

        [Display(Name="Brand Image")]
        public int ImageId { get; set; }

    }
}
