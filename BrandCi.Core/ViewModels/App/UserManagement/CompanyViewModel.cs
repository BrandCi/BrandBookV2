using System.Collections;
using System.Collections.Generic;

namespace BrandCi.Core.ViewModels.App.UserManagement
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

        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlName { get; set; }
        public string ContactEmail { get; set; }
        public int NumberOfUser { get; set; }

    }

}
