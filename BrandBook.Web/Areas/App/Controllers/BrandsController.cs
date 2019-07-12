using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Core.Domain.Brand;
using BrandBook.Infrastructure;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Brand;
using BrandBook.Services.Authentication;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Brand;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class BrandsController : AppControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private CompanyAuthorizationService _cmpAuthService;

        public BrandsController()
        {
            this._unitOfWork = new UnitOfWork();
            this._cmpAuthService = new CompanyAuthorizationService();
        }



        // GET: App/Brands
        public ActionResult Overview()
        {
            var allBrands = _unitOfWork.BrandRepository.GetAll();
            List<SingleBrandOverviewViewModel> singleBrandViewModels = new List<SingleBrandOverviewViewModel>();

            foreach (Brand singleBrand in allBrands)
            {
                string userGuid = User.Identity.GetUserId();

                if (_cmpAuthService.IsAuthorized(userGuid, singleBrand.Id))
                {
                    singleBrandViewModels.Add(new SingleBrandOverviewViewModel()
                    {
                        Id = singleBrand.Id,
                        Name = singleBrand.Name,
                        Image = singleBrand.ImageName + "." + singleBrand.ImageType,
                        ShortDescription = singleBrand.ShortDescription,
                        MainHexColor = singleBrand.MainHexColor
                    });
                }
                
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
                
                _unitOfWork.BrandRepository.Add(brand);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Overview", "Brands", new {area = "App"});
            }

            return View(model);
        }

    }
}   