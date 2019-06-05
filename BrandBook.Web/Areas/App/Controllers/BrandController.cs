using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Core.RepositoryInterfaces.Brand;
using BrandBook.Infrastructure;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Brand;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Brand;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class BrandController : AppControllerBase
    {
        private IUnitOfWork unitOfWork;

        public BrandController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        // GET: App/Brand
        public ActionResult Index(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Overview", "Brands", new {area = "App"});
            }

            ViewBag.BrandId = id;

            try
            {
                var brand = unitOfWork.BrandRepository.FindById(id);

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
            catch (Exception ex)
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }

            
            
        }


        public ActionResult Settings(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }

            return View();
        }


        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }




            return RedirectToAction("Overview", "Brands", new { area = "App" });
        }
    }
}