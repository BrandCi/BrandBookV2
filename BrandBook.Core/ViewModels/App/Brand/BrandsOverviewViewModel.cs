using System.Collections;
using System.Collections.Generic;

namespace BrandBook.Core.ViewModels.App.Brand
{
    public class BrandsOverviewViewModel : IEnumerable<SingleBrandOverviewViewModel>
    {
        public List<SingleBrandOverviewViewModel> Brands { get; set; }
        public bool HasValidSubscription { get; set; }
        public bool AllowedToCreateNewBrands { get; set; }
        public bool NoBrandsAvailable { get; set; }

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
