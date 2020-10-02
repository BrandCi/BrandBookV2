using BrandBook.Core;
using BrandBook.Core.Domain.Resource;
using BrandBook.Core.Services.Subscriptions;
using BrandBook.Core.ViewModels.App.Brand;
using BrandBook.Infrastructure;
using BrandBook.Services.Authentication;
using BrandBook.Services.Resources;
using BrandBook.Services.Subscriptions;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using log4net;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.App.Controllers.Brand
{
    public class BrandsController : AppMvcControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionService _subscriptionService;
        private readonly CompanyAuthorizationService _cmpAuthService;
        private readonly ImageService _imageService;

        protected static new readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        #endregion


        #region Constructor
        public BrandsController()
        {
            _unitOfWork = new UnitOfWork();
            _cmpAuthService = new CompanyAuthorizationService();
            _imageService = new ImageService();
            _subscriptionService = new SubscriptionService();
        }
        #endregion


        #region Public Actions
        public ActionResult Overview()
        {
            var allBrands = _unitOfWork.BrandRepository.GetAll().OrderBy(b => b.Name);
            var userId = User.Identity.GetUserId<int>();
            var singleBrandViewModels = new List<SingleBrandOverviewViewModel>();

            foreach (var singleBrand in allBrands)
            {

                if (_cmpAuthService.IsAuthorized(userId, singleBrand.Id))
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
                HasValidSubscription = _subscriptionService.HasValidSubscription(userId),
                AllowedToCreateNewBrands = _subscriptionService.AllowedToCreateNewBrands(userId),
                NoBrandsAvailable = false
            };

            if (singleBrandViewModels.Count() == 0)
            {
                viewmodel.NoBrandsAvailable = true;
            }


            return View(viewmodel);
        }

        public ActionResult Add()
        {
            var model = new AddNewBrandViewModel();

            return View(model);
        }
        #endregion


        #region Public POST Actions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddNewBrandViewModel model, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid || !_subscriptionService.HasValidSubscription(User.Identity.GetUserId<int>()))
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
            return RedirectToAction("Index", "Brand", new { id = brand.Id, area = "App" });

        }
        #endregion


        #region Helper Methods
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
        #endregion
    }
}