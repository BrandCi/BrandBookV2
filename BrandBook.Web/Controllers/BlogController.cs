using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core.Repositories.Frontend;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Frontend;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.Frontend.Blog;

namespace BrandBook.Web.Controllers
{
    public class BlogController : FrontendControllerBase
    {
        private readonly IBlogEntryRepository _blogEntryRepository;

        public BlogController()
        {
            _blogEntryRepository = new BlogEntryRepository( new BrandBookDbContext() );
        }


        // GET: Blog
        public ActionResult Index(string blogName = "")
        {
            if (blogName == "")
            {
                return RedirectToAction("Overview");
            }

            var blog = _blogEntryRepository.FindBlogEntryByKey(blogName);

            var viewModel = new BlogEntryViewModel()
            {
                UrlKey = blog.UrlKey,
                Title = blog.Title,
                SubTitle = blog.SubTitle,
                Image = blog.Image,
                Content = blog.Content,
                Author = blog.Author,
                CreationDateTime = blog.CreationDateTime

            };

            return View(viewModel);
        }


        public ActionResult Overview()
        {
            return View();
        }
    }
}
