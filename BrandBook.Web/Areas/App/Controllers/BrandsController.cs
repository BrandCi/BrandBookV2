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
using BrandBook.Services.Authentication;
using BrandBook.Services.Resources;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Brand;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class BrandsController : AppControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private CompanyAuthorizationService _cmpAuthService;
        private ImageService _imageService;

        public BrandsController()
        {
            this._unitOfWork = new UnitOfWork();
            this._cmpAuthService = new CompanyAuthorizationService();
            this._imageService = new ImageService();
        }



        // GET: App/Brands
        public ActionResult Overview()
        {
            var allBrands = _unitOfWork.BrandRepository.GetAll();
            var singleBrandViewModels = new List<SingleBrandOverviewViewModel>();

            foreach (var singleBrand in allBrands)
            {
                var userGuid = User.Identity.GetUserId();

                if (_cmpAuthService.IsAuthorized(userGuid, singleBrand.Id))
                {
                    var brandImage = _unitOfWork.ImageRepository.FindById(singleBrand.ImageId);

                    singleBrandViewModels.Add(new SingleBrandOverviewViewModel()
                    {
                        Id = singleBrand.Id,
                        Name = singleBrand.Name,
                        ShortDescription = singleBrand.ShortDescription,
                        MainHexColor = singleBrand.MainHexColor,
                        BrandImage = new BrandImageViewModel()
                        {
                            Id = brandImage.Id,
                            Name = brandImage.Name
                        }
                    });
                }
                
            }

            var viewmodel = new BrandsOverviewViewModel
            {
                Brands = singleBrandViewModels
            };


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
                Image brandImage;
                if (image != null)
                {
                    var fileName = _imageService.GenerateRandomImageName() + "." + _imageService.ExtractTypeFromImageName(image.FileName);

                    SaveBrandImageInStorage(image, fileName);
                    
                    brandImage = new Image()
                    {
                        Name = fileName,
                        ContentType = image.ContentType,
                        Category = 1
                    };

                    _unitOfWork.ImageRepository.Add(brandImage);
                }
                else
                {
                    brandImage = _unitOfWork.ImageRepository.FindById(1);
                }

                


                var brand = new Brand()
                {
                    Name = model.Name,
                    Description = model.Description,
                    MainHexColor = model.MainColor,
                    ImageId = brandImage.Id,
                    Image = brandImage,
                    BrandPublicSettingId = 1,
                    BrandSettingId = 2,
                    CompanyId = _unitOfWork.AppUserRepository.GetCompanyIdByUsername(User.Identity.GetUserName())
                };

                _unitOfWork.BrandRepository.Add(brand);

                _unitOfWork.SaveChanges();
                return RedirectToAction("Overview", "Brands", new {area = "App"});
            }

            return View(model);
        }




        private void SaveBrandImageInStorage(HttpPostedFileBase image, string fileName)
        {
            var filePath = Server.MapPath("/SharedStorage/BrandImages");

            image.SaveAs(Path.Combine(filePath, fileName));
        }


    }
}   