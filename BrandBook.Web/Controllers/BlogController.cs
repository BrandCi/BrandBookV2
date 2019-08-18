using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core.Repositories.Frontend;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Frontend;
using BrandBook.Web.Framework.Controllers;

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
            return View();
        }


        public ActionResult Overview()
        {
            return View();
        }
    }
}