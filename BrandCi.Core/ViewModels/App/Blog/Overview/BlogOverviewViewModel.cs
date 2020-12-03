using System.Collections;
using System.Collections.Generic;

namespace BrandCi.Core.ViewModels.App.Blog.Overview
{
    public class BlogOverviewViewModel : IEnumerable<SingleBlogOverviewItemViewModel>
    {
        public List<SingleBlogOverviewItemViewModel> SingleBlogItems { get; set; }

        public IEnumerator<SingleBlogOverviewItemViewModel> GetEnumerator()
        {
            return SingleBlogItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
