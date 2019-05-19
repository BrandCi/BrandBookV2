using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Profile
{
    public class GeneralUserDataViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
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
