using System.Collections;
using System.Collections.Generic;

namespace BrandBook.Web.Framework.ViewModels.Frontend.Blog
{
    public class BlogOverviewViewModel : IEnumerable<BlogEntryViewModel>
    {

        public List<BlogEntryViewModel> BlogEntryViewModels { get; set; }

        public IEnumerator<BlogEntryViewModel> GetEnumerator()
        {
            return BlogEntryViewModels.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
