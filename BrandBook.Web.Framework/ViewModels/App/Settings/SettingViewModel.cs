using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Settings
{
    public class SettingViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
