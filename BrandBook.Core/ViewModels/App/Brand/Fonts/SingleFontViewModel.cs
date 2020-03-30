using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.ViewModels.App.Brand.Fonts
{
    public class SingleFontViewModel : IEnumerable<FontStyleViewModel>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string GoogleFontLink { get; set; }

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
