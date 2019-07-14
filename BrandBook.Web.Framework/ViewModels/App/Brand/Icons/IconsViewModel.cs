using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Icons
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
