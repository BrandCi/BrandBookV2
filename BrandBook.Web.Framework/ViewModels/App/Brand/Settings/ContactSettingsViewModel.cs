using System.ComponentModel.DataAnnotations;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Settings
{
    public class ContactSettingsViewModel
    {
        [Required(ErrorMessage = "Please define your Contact Person Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid Email Address")]
        public string ContactPerson { get; set; }
    }
}
