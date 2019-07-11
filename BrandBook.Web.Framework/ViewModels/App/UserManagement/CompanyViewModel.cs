using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.UserManagement
{

    public class CompaniesOverviewViewModel : IEnumerable<SingleCompanyViewModel>
    {
        public List<SingleCompanyViewModel> Companies { get; set; }

        public IEnumerator<SingleCompanyViewModel> GetEnumerator()
        {
            return Companies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class SingleCompanyViewModel
    {

        public string Name { get; set; }
        public string UrlName { get; set; }
        public string ContactEmail { get; set; }

    }

}
