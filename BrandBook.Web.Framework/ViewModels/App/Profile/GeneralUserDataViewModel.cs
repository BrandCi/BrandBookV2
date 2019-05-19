using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Resources;

namespace BrandBook.Web.Framework.ViewModels.App.Profile
{
    public class GeneralUserDataViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "auth_register_input_password", ResourceType = typeof(Translations))]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "auth_register_input_confirmpassword", ResourceType = typeof(Translations))]
        [Compare("Password", ErrorMessage = "Die Passwörter stimmen nicht überein")]
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        

        public GeneralUserDataViewModel(string id, string userName, string email)
        {
            this.Id = id;
            this.UserName = userName;
            // this.FirstName = firstName;
            // this.LastName = lastName;
            this.Email = email;
        }

    }
}
