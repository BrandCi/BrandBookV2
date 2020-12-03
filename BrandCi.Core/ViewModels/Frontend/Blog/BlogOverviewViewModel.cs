using System.Collections;
using System.Collections.Generic;

namespace BrandCi.Core.ViewModels.Frontend.Blog
{
    public class BlogOverviewViewModel : IEnumerable<SingleBlogOverviewViewModel>
    {

        public List<SingleBlogOverviewViewModel> BlogEntries { get; set; }

        public IEnumerator<SingleBlogOverviewViewModel> GetEnumerator()
        {
            return BlogEntries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
