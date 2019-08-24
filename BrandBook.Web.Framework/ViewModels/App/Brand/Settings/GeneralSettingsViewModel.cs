using System.ComponentModel.DataAnnotations;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Settings
{
    public class GeneralSettingsViewModel
    {
        [Required (ErrorMessage = "Please define a Name for your Brand")]
        public string Name { get; set; }

        [StringLength(6, MinimumLength = 6,
            ErrorMessage = "Your Hex-Value should be exactly 6 chars")]
        public string MainHexColor { get; set; }
    }
}
