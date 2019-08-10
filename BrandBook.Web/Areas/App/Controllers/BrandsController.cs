using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Core.Domain.Brand;
using BrandBook.Core.Domain.Resource;
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
        [Authorize(Roles = "Administrator")]
        public ActionResult Add(AddNewBrandViewModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                

                if (image != null)
                {
                    var separatedImageName = image.FileName.Split('.');
                    var imgType = separatedImageName[separatedImageName.Length - 1];

                    // Save Image in Storage
                    var fileName = GenerateRandomImageName() + "." + imgType;
                    var filePath = Server.MapPath("/SharedStorage/BrandImages");

                    image.SaveAs(Path.Combine(filePath, fileName));


                    
                    var brandImage = new Image()
                    {
                        Name = image.FileName,
                        ContentType = image.ContentType,
                        Category = 1
                    };

                }


                var brand = new Brand()
                {
                    Name = model.Name,
                    Description = model.Description,
                    MainHexColor = model.MainColor,
                    ImageId = 1

                };

                _unitOfWork.BrandRepository.Add(brand);

                _unitOfWork.SaveChanges();
                return RedirectToAction("Overview", "Brands", new {area = "App"});
            }

            return View(model);
        }
        


        private string GenerateRandomImageName()
        {
            var random = new Random();

            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, 15)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }

    }
}   