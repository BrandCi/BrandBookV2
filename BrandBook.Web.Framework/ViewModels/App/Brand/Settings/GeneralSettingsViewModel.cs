using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
