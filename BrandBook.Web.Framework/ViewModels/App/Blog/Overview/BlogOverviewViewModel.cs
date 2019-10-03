using System;
using System.Collections;
using System.Collections.Generic;

namespace BrandBook.Web.Framework.ViewModels.App.Blog.Overview
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
