using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Settings
{
    public class ContactSettingsViewModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Please define your Contact Person Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid Email Address")]
        public string ContactPerson { get; set; }
    }
}
