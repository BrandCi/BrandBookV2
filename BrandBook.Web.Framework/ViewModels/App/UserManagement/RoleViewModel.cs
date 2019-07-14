using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.UserManagement
{
    public class RoleOverviewViewModel : IEnumerable<SingleRoleViewModel>
    {
        public List<SingleRoleViewModel> Roles { get; set; }

        public IEnumerator<SingleRoleViewModel> GetEnumerator()
        {
            return Roles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class SingleRoleViewModel
    {

        public string Id { get; set; }
        public string Name { get; set; }
        
    }
}
