using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Blog.Overview;

namespace BrandBook.Web.Areas.App.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BlogController : AppControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public BlogController()
        {
            this._unitOfWork = new UnitOfWork();
        }


        // GET: App/Blog
        public async Task<ActionResult> Index()
        {

            var blogs = await _unitOfWork.BlogEntryRepository.GetAllAsync();

            var viewModel = new BlogOverviewViewModel()
            {
                SingleBlogItems = new List<SingleBlogOverviewItemViewModel>()
            };



            foreach (var blog in blogs)
            {
                viewModel.SingleBlogItems.Add(new SingleBlogOverviewItemViewModel()
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    UrlKey = blog.UrlKey,
                    IsPublished = blog.IsPublished,
                    CreationDate = blog.CreationDateTime
                });
            }




            return View(viewModel);
        }
    }
}