using BrandCi.Core.Repositories.Frontend;
using BrandCi.Infrastructure.Data;
using BrandCi.Infrastructure.Repositories.Frontend;
using BrandCi.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandCi.Web.Controllers
{
    public class BlogController : FrontendMvcControllerBase
    {
        private readonly IBlogEntryRepository _blogEntryRepository;

        public BlogController()
        {
            _blogEntryRepository = new BlogEntryRepository(new BrandBookDbContext());
        }


        // GET: Blog
        public ActionResult Index(string blogName = "")
        {

            if (blogName == "" || !_blogEntryRepository.BlogEntryExistsAndPublished(blogName))
            {
                return RedirectToAction("Overview");
            }

            var blog = _blogEntryRepository.FindBlogEntryByKey(blogName);

            ViewBag.Title = blog.Title;
            ViewBag.MetaKeywords = "";
            ViewBag.MetaDescription = "";


            return View();
        }


        public ActionResult Overview()
        {

            return View();
        }
    }
}