using System.ComponentModel.DataAnnotations;

namespace BrandBook.Core.ViewModels.App.Brand.Settings
{
    public class BrandSettingsViewModel
    {
        [Required]
        public int Id { get; set; }

        public GeneralSettingsViewModel GeneralSettingsViewModel { get; set; }
        public ContactSettingsViewModel ContactSettingsViewModel { get; set; }
        public CustomizingSettingsViewModel CustomizingSettingsViewModel { get; set; }
    }
}
