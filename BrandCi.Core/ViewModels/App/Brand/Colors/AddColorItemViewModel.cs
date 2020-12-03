using System.ComponentModel.DataAnnotations;

namespace BrandCi.Core.ViewModels.App.Brand.Colors
{
    public class AddColorItemViewModel
    {
        public int BrandId { get; set; }
        public string Name { get; set; }

        [MaxLength(6)]
        public string HexColor { get; set; }

    }
}
