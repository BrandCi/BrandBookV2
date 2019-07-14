using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Settings
{
    public class UserSettingsViewModel
    {
        [Display(Name="Required Length")]
        public string Password_ReqLength { get; set; }

        [Display(Name = "Require Non Letter or Digit")]
        public string Password_ReqNonLetterOrDigit { get; set; }

        [Display(Name = "Require Digit")]
        public string Password_ReqDigit { get; set; }

        [Display(Name = "Require Lowercase")]
        public string Password_ReqLowerCase { get; set; }

        [Display(Name = "Require Uppercase")]
        public string Password_ReqUpperCase { get; set; }


        [Display(Name = "Enabled")]
        public string Lockout_Enabled { get; set; }

        [Display(Name = "Lockout Time")]
        public string Lockout_LockoutTime { get; set; }

        [Display(Name = "Max Failed Attempts")]
        public string Lockout_FailedAttempts { get; set; }
    }
}
