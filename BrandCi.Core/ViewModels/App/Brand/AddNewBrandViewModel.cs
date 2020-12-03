using System.ComponentModel.DataAnnotations;

namespace BrandCi.Core.ViewModels.App.Brand
{
    public class AddNewBrandViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [MaxLength(255)]
        public string ShortDescription { get; set; }

        public string MainColor { get; set; }

        public int ImageId { get; set; }

    }
}