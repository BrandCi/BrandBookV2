using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Brand;
using BrandBook.Services.Authentication;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Brand;
using BrandBook.Web.Framework.ViewModels.App.Brand.Colors;
using BrandBook.Web.Framework.ViewModels.App.Brand.Settings;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class BrandController : AppControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private CompanyAuthorizationService _cmpAuthService;

        public BrandController()
        {
            this._unitOfWork = new UnitOfWork();
            this._cmpAuthService = new CompanyAuthorizationService();
        }

        // GET: App/Brand
        public async Task<ActionResult> Index(int id)
        {
            ViewBag.BrandId = id;

            if (!_cmpAuthService.IsAuthorized(User.Identity.GetUserId(), id))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }

            try
            {
                var brand = await _cmpAuthService.GetBrandAsync(User.Identity.GetUserId(), id);

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



        public ActionResult Colors(int id)
        {
            ViewBag.BrandId = id;

            if (!_cmpAuthService.IsAuthorized(User.Identity.GetUserId(), id))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }


            var categories = _unitOfWork.ColorCategoryRepository.GetCategoriesForBrand(id);

            ColorsViewModel model = new ColorsViewModel();
            model.Categories = new List<ColorCategoryViewModel>();


            foreach (var category in categories)
            {
                var colors = _unitOfWork.ColorRepository.GetAllColorsFromCategory(category.Id);

                List<SingleColorViewModel> singleColors = new List<SingleColorViewModel>();

                foreach (var color in colors)
                {
                    Color _color = System.Drawing.ColorTranslator.FromHtml("#" + color.HexColorCode);
                    string _rgb = "" + _color.R + ", " + _color.G + ", " + _color.B;

                    singleColors.Add(new SingleColorViewModel()
                    {
                        Name = color.Name,
                        HexColor = color.HexColorCode,
                        RgbValue = _rgb,
                        CmykValue = ""
                    });
                }

                model.Categories.Add(new ColorCategoryViewModel()
                {
                    Name = category.Name,
                    Colors = singleColors

                });
            }

          
            return View(model);
        }

        public ActionResult Fonts(int id)
        {

            if (!_cmpAuthService.IsAuthorized(User.Identity.GetUserId(), id))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }


            return View();
        }




        public ActionResult Settings(int id)
        {
            ViewBag.BrandId = id;

            if (!_cmpAuthService.IsAuthorized(User.Identity.GetUserId(), id))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }


            var brand = _unitOfWork.BrandRepository.FindById(id);

            var model = new BrandSettingsViewModel()
            {
                Id = brand.Id,

                GeneralSettingsViewModel = new GeneralSettingsViewModel()
                {
                    Name = brand.Name,
                    MainHexColor = brand.MainHexColor
                },

                ContactSettingsViewModel = new ContactSettingsViewModel()
                {
                    ContactPerson = "info@philipp-moser.de"
                },

                CustomizingSettingsViewModel = new CustomizingSettingsViewModel()
                {
                    PrimaryHexColor = "193357",
                    RoundedButtons = true,
                    RoundedButtonsPixel = 5
                }
            };


            return View(model);
        }






        [HttpPost]
        public ActionResult UpdateGeneralSettings(BrandSettingsViewModel model)
        {
            if (!ModelState.IsValid || !_cmpAuthService.IsAuthorized(User.Identity.GetUserId(), model.Id))
            {
                return RedirectToAction("Settings", "Brand", new { id = model.Id, area = "App" });
            }


            // Get current brand
            var brand = _unitOfWork.BrandRepository.FindById(model.Id);

            // Set updated values
            brand.Name = model.GeneralSettingsViewModel.Name;
            brand.MainHexColor = model.GeneralSettingsViewModel.MainHexColor;

            // Update
            _unitOfWork.BrandRepository.Update(brand);
            _unitOfWork.SaveChanges();



            return RedirectToAction("Settings", "Brand", new { id = model.Id, area = "App"});
        }


        [HttpPost]
        public ActionResult UpdateContactSettings(BrandSettingsViewModel model)
        {
            if (!ModelState.IsValid || !_cmpAuthService.IsAuthorized(User.Identity.GetUserId(), model.Id))
            {
                return RedirectToAction("Settings", "Brand", new { id = model.Id, area = "App" });
            }


            // Get current brand
            var brand = _unitOfWork.BrandRepository.FindById(model.Id);

            // Set updated values
            brand.BrandSetting.ContactEmail = model.ContactSettingsViewModel.ContactPerson;

            // Update
            _unitOfWork.BrandRepository.Update(brand);
            _unitOfWork.SaveChanges();



            return RedirectToAction("Settings", "Brand", new { id = model.Id, area = "App" });
        }




        public ActionResult Delete(int id)
        {
            if (!_cmpAuthService.IsAuthorized(User.Identity.GetUserId(), id))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }

            var brand = _unitOfWork.BrandRepository.FindById(id);

            _unitOfWork.BrandRepository.Remove(brand);
            _unitOfWork.SaveChanges();


            return RedirectToAction("Overview", "Brands", new { area = "App" });
        }


    }
}