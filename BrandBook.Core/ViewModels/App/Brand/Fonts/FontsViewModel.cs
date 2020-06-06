using System.Collections;
using System.Collections.Generic;

namespace BrandBook.Core.ViewModels.App.Brand.Fonts
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
