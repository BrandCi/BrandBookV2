using System.Collections;
using System.Collections.Generic;

namespace BrandCi.Core.ViewModels.App.UserManagement
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

}
