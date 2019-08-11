using System.Collections;
using System.Collections.Generic;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Colors
{
    public class ColorCategoryViewModel : IEnumerable<SingleColorViewModel>
    {

        public string Name { get; set; }
        public List<SingleColorViewModel> Colors { get; set; }

        public IEnumerator<SingleColorViewModel> GetEnumerator()
        {
            return Colors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
