using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Fonts
{
    public class SingleFontViewModel : IEnumerable<FontStyleViewModel>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public FontInclusionViewModel FontInclusion { get; set; }

        public List<FontStyleViewModel> FontStyles { get; set; }

        public IEnumerator<FontStyleViewModel> GetEnumerator()
        {
            return FontStyles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
