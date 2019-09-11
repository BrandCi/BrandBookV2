using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Fonts
{
    public class FontsViewModel : IEnumerable<SingleFontViewModel>
    {
        public List<SingleFontViewModel> Fonts { get; set; }

        public IEnumerator<SingleFontViewModel> GetEnumerator()
        {
            return Fonts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
