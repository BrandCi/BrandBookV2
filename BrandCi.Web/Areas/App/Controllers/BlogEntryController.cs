using BrandBook.Core;
using BrandBook.Core.Domain.Frontend;
using BrandBook.Core.ViewModels.App.Blog;
using BrandBook.Core.ViewModels.App.Blog.Overview;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.App.Controllers
{
    [Authorize(Roles = "BlogManager")]
    public class BlogEntryController : AppMvcControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        #region Constructor
        public BlogEntryController()
        {
            this._unitOfWork = new UnitOfWork();
        }
        #endregion


        #region Actions
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
                    PublishDate = blog.PublishDate
                });
            }

            return View(viewModel);
        }

        public ActionResult Add()
        {
            var viewModel = new AddBlogEntryViewModel()
            {
                PublishDate = DateTime.Now
            };

            return View(viewModel);
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (!_unitOfWork.BlogEntryRepository.BlogEntryIdExists(id))
            {
                return RedirectToAction("Index", "BlogEntry", new { area = "App" });
            }

            var blogEntry = await _unitOfWork.BlogEntryRepository.FindByIdAsync(id);

            var viewModel = new EditBlogEntryViewModel()
            {
                Id = blogEntry.Id,
                Title = blogEntry.Title,
                SubTitle = blogEntry.SubTitle,
                IsPublished = blogEntry.IsPublished,
                IsVisibleForAnonymous = blogEntry.IsVisibleForAnonymous,
                UrlKey = blogEntry.UrlKey,
                AdditionalStyles = blogEntry.AdditionalStyles,
                Content = blogEntry.Content,
                Author = blogEntry.Author,
                PublishDate = blogEntry.PublishDate
            };



            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            if (!_unitOfWork.BlogEntryRepository.BlogEntryIdExists(id))
            {
                return RedirectToAction("Index", "BlogEntry", new { area = "App" });
            }

            var blogEntry = _unitOfWork.BlogEntryRepository.FindById(id);

            _unitOfWork.BlogEntryRepository.Remove(blogEntry);
            _unitOfWork.SaveChanges();


            return RedirectToAction("Index", "BlogEntry", new { area = "App" });
        }
        #endregion


        #region Public POST Actions
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(AddBlogEntryViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var blogEntry = new BlogEntry()
            {
                Title = model.Title,
                SubTitle = model.SubTitle,
                Content = model.Content,
                AdditionalStyles = model.AdditionalStyles,
                Author = model.Author,
                PublishDate = model.PublishDate,

                IsPublished = false,
                IsVisibleForAnonymous = false,
                UrlKey = GenerateUrlKey(),
                CreationDateTime = DateTime.Now,

                BlogImageId = 1,
                AppUserId = User.Identity.GetUserId<int>()

            };

            _unitOfWork.BlogEntryRepository.Add(blogEntry);
            _unitOfWork.SaveChanges();


            return RedirectToAction("Index", "BlogEntry", new { area = "App" });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(EditBlogEntryViewModel model)
        {

            if (!ModelState.IsValid || !_unitOfWork.BlogEntryRepository.BlogEntryIdExists(model.Id) || _unitOfWork.BlogEntryRepository.BlogEntryKeyExists(model.UrlKey))
            {
                return View(model);
            }

            var blogEntry = await _unitOfWork.BlogEntryRepository.FindByIdAsync(model.Id);

            blogEntry.Title = model.Title;
            blogEntry.SubTitle = model.SubTitle;
            blogEntry.UrlKey = model.UrlKey;
            blogEntry.Content = model.Content;
            blogEntry.AdditionalStyles = model.AdditionalStyles;
            blogEntry.Author = model.Author;
            blogEntry.PublishDate = model.PublishDate;
            blogEntry.IsPublished = model.IsPublished;
            blogEntry.IsVisibleForAnonymous = model.IsVisibleForAnonymous;

            _unitOfWork.BlogEntryRepository.Update(blogEntry);
            _unitOfWork.SaveChanges();


            return RedirectToAction("Index", "BlogEntry", new { area = "App" });

        }
        #endregion


        #region Helper Methods
        private static string GenerateUrlKey()
        {
            var random = new Random();

            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, 20)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }
        #endregion
    }
}