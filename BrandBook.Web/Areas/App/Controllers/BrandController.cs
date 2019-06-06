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
using BrandBook.Web.Framework.ViewModels.App.Brand.Settings;

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
                    ShortDescription = brand.ShortDescription,
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
            ViewBag.BrandId = id;

            if (id == null || id == 0)
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }


            var brand = unitOfWork.BrandRepository.FindById(id);

            var model = new BrandSettingsViewModel()
            {
                GeneralSettingsViewModel = new GeneralSettingsViewModel()
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    MainHexColor = brand.MainHexColor
                },

                ContactSettingsViewModel = new ContactSettingsViewModel()
            };


            return View(model);
        }












        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }

            var brand = unitOfWork.BrandRepository.FindById(id);

            unitOfWork.BrandRepository.Remove(brand);
            unitOfWork.SaveChanges();


            return RedirectToAction("Overview", "Brands", new { area = "App" });
        }
    }
}