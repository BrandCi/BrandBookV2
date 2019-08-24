using System.Collections;
using System.Collections.Generic;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Colors
{
    public class ColorsViewModel : IEnumerable<ColorCategoryViewModel>
    {

        public List<ColorCategoryViewModel> Categories { get; set; }

        public IEnumerator<ColorCategoryViewModel> GetEnumerator()
        {
            return Categories.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


    }

}
