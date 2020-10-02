using System.Collections;
using System.Collections.Generic;

namespace BrandCi.Core.ViewModels.App.Brand.Colors
{
    public class ColorsViewModel : IEnumerable<ColorCategoryViewModel>
    {

        public List<ColorCategoryViewModel> Categories { get; set; }
        public AddColorItemViewModel AddColorItem { get; set; }

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
