using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Settings
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
