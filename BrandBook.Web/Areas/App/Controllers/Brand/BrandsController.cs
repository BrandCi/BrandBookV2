using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Core.Domain.Resource;
using BrandBook.Infrastructure;
using BrandBook.Services.Authentication;
using BrandBook.Services.Resources;
using BrandBook.Services.Subscriptions;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using BrandBook.Core.ViewModels.App.Brand;
using log4net;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Areas.App.Controllers.Brand
{
    public class BrandsController : AppControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CompanyAuthorizationService _cmpAuthService;
        private readonly ImageService _imageService;
        private readonly SubscriptionService _subscriptionService;
        protected new static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        public BrandsController()
        {
            _unitOfWork = new UnitOfWork();
            _cmpAuthService = new CompanyAuthorizationService();
            _imageService = new ImageService();
            _subscriptionService = new SubscriptionService();
        }



        // GET: App/Brands
        public ActionResult Overview()
        {
            var allBrands = _unitOfWork.BrandRepository.GetAll().OrderBy(b => b.Name);
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
                Brands = singleBrandViewModels,
                HasValidSubscription = _subscriptionService.HasValidSubscription(User.Identity.GetUserId())
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
        public ActionResult Add(AddNewBrandViewModel model, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid || !_subscriptionService.HasValidSubscription(User.Identity.GetUserId()))
            {
                return View(model);
            }


            Image brandImage;
            if (image != null)
            {
                var fileName = _imageService.GenerateRandomImageName() + "." + _imageService.GetImageType(image.FileName);

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


            var brand = new Core.Domain.Brand.Brand()
            {
                Name = model.Name,
                Description = model.Description,
                ShortDescription = model.ShortDescription,
                MainHexColor = model.MainColor,
                ImageId = brandImage.Id,
                Image = brandImage,
                CompanyId = _unitOfWork.AppUserRepository.GetCompanyIdByUsername(User.Identity.GetUserName())
            };

            _unitOfWork.BrandRepository.Add(brand);

            _unitOfWork.SaveChanges();
            return RedirectToAction("Index", "Brand", new {id = brand.Id, area = "App"});

        }




        private void SaveBrandImageInStorage(HttpPostedFileBase image, string fileName)
        {
            var filePath = Server.MapPath("/SharedStorage/BrandImages");

            try
            {
                image.SaveAs(Path.Combine(filePath, fileName));
            }
            catch (FileNotFoundException ex)
            {
                Logger.Warn(ex.Message, ex);
            }
            catch (Exception ex)
            {
                Logger.Warn(ex.Message, ex);
            }

        }


    }
}