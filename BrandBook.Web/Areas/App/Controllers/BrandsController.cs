using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core.Domain.Brand;
using BrandBook.Core.RepositoryInterfaces.Brand;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Brand;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Brand;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class BrandsController : AppControllerBase
    {
        private IBrandRepository brandRepository;

        public BrandsController()
        {
            this.brandRepository = new BrandRepository(new BrandBookDbContext());
        }



        // GET: App/Brands
        public ActionResult Overview()
        {
            var allBrands = brandRepository.GetAll();
            List<SingleBrandOverviewViewModel> singleBrandViewModels = new List<SingleBrandOverviewViewModel>();

            foreach (Brand singleBrand in allBrands) 
            {
                singleBrandViewModels.Add(new SingleBrandOverviewViewModel()
                {
                    Id = singleBrand.Id,
                    Name = singleBrand.Name,
                    Image = singleBrand.ImageName + "." + singleBrand.ImageType,
                    Description = singleBrand.Description,
                    MainHexColor = singleBrand.MainHexColor
                });
            }

            BrandsOverviewViewModel viewmodel = new BrandsOverviewViewModel();
            viewmodel.Brands = singleBrandViewModels;


            return View(viewmodel);
        }


        public ActionResult Add()
        {
            var model = new AddNewBrandViewModel();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddNewBrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brand = new Brand()
                {
                    Name = model.Name,
                    Description = model.Description,
                    MainHexColor = model.MainColor,
                    ImageName = model.Image,
                    ImageType = "png"
                };
                
                brandRepository.Add(brand);
                return RedirectToAction("Overview", "Brands", new {area = "App"});
            }

            return View(model);
        }

    }
}   