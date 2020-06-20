using System.ComponentModel.DataAnnotations;

namespace BrandBook.Core.ViewModels.App.Brand.Colors
{
    public class AddColorItemViewModel
    {
        public int BrandId { get; set; }
        public string Name { get; set; }

        [MaxLength(6)]
        public string HexColor { get; set; }

    }
}
