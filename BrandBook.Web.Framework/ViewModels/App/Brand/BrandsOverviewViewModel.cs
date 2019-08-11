using System.Collections;
using System.Collections.Generic;

namespace BrandBook.Web.Framework.ViewModels.App.Brand
{
    public class BrandsOverviewViewModel : IEnumerable<SingleBrandOverviewViewModel>
    {
        public List<SingleBrandOverviewViewModel> Brands { get; set; }

        public IEnumerator<SingleBrandOverviewViewModel> GetEnumerator()
        {
            return Brands.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
