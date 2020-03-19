using System.Collections;
using System.Collections.Generic;

namespace BrandBook.Core.ViewModels.App.Brand.Icons
{
    public class IconsViewModel : IEnumerable<IconCategoryViewModel>
    {

        public List<IconCategoryViewModel> Categories { get; set; }

        public IEnumerator<IconCategoryViewModel> GetEnumerator()
        {
            return Categories.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
