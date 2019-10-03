﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Core.Domain.Frontend;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Blog;
using BrandBook.Web.Framework.ViewModels.App.Blog.Overview;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Areas.App.Controllers
{
    [Authorize(Roles = "BlogManager")]
    public class BlogEntryController : AppControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public BlogEntryController()
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



        public ActionResult Add()
        {
            var viewModel = new AddBlogEntryViewModel()
            {
                PublishDate = DateTime.Now
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(AddBlogEntryViewModel model)
        {

            if(!ModelState.IsValid)
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
                AppUserId = User.Identity.GetUserId()

            };

            _unitOfWork.BlogEntryRepository.Add(blogEntry);
            _unitOfWork.SaveChanges();


            return RedirectToAction("Index", "BlogEntry", new { area="App" });

        }



        public async Task<ActionResult> Edit(int id)
        {
            if (!_unitOfWork.BlogEntryRepository.BlogEntryIdExists(id))
            {
                return RedirectToAction("Index", "BlogEntry", new {area = "App"});
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
                Author = blogEntry.Author
            };



            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(EditBlogEntryViewModel model)
        {
            
            if (!ModelState.IsValid || !_unitOfWork.BlogEntryRepository.BlogEntryIdExists(model.Id))
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
            blogEntry.IsPublished = model.IsPublished;
            blogEntry.IsVisibleForAnonymous = model.IsVisibleForAnonymous;

            _unitOfWork.BlogEntryRepository.Update(blogEntry);
            _unitOfWork.SaveChanges();
            

            return RedirectToAction("Index", "BlogEntry", new {area = "App"});

        }










        private static string GenerateUrlKey()
        {
            var random = new Random();

            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, 20)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }


    }
}