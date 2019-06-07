using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Settings
{
    public class CustomizingSettingsViewModel
    {
        public string PrimaryHexColor { get; set; }
        public bool RoundedButtons { get; set; }
        public int RoundedButtonsPixel { get; set; }
    }
}
