using System.Collections;
using System.Collections.Generic;

namespace BrandBook.Core.ViewModels.App.UserManagement
{
    public class AppUserViewModel : IEnumerable<SingleAppUserViewModel>
    {
        public List<SingleAppUserViewModel> AppUsers { get; set; }



        public IEnumerator<SingleAppUserViewModel> GetEnumerator()
        {
            return AppUsers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class SingleAppUserViewModel
    {

        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
