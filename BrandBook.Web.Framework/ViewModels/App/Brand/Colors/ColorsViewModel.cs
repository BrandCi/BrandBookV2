using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
