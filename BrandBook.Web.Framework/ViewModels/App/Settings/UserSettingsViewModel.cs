using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Settings
{
    public class UserSettingsViewModel
    {
        public string Password_ReqLength { get; set; }
        public string Password_ReqNonLetterOrDigit { get; set; }
        public string Password_ReqDigit { get; set; }
        public string Password_ReqLowerCase { get; set; }
        public string Password_ReqUpperCase { get; set; }


        public string Lockout_Enabled { get; set; }
        public string Lockout_LockoutTime { get; set; }
        public string Lockout_FailedAttempts { get; set; }
    }
}
