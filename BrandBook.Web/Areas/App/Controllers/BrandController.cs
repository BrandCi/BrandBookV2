using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core.RepositoryInterfaces.Brand;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Brand;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Brand;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class BrandController : AppControllerBase
    {

        private IBrandRepository brandRepository;

        public BrandController()
        {
            this.brandRepository = new BrandRepository(new BrandBookDbContext());
        }

        // GET: App/Brand
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Overview", "Brands", new {area = "App"});
            }


            ViewBag.BrandId = id;

            var brand = brandRepository.FindById(id);

            var model = new BrandOverviewViewModel()
            {
                Id = brand.Id,
                Name = brand.Name,
                Description = brand.Description,
                MainHexColor = brand.MainHexColor,
                ImageName = brand.ImageName,
                ImageType = brand.ImageType
            };


            return View(model);
        }
    }
}