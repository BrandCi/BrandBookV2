using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Web.Framework.ViewModels.App.Brand;

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
