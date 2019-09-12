using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Services.Authentication;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Brand;
using BrandBook.Web.Framework.ViewModels.App.Brand.Colors;
using BrandBook.Web.Framework.ViewModels.App.Brand.Icons;
using BrandBook.Web.Framework.ViewModels.App.Brand.Settings;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Image = BrandBook.Core.Domain.Resource.Image;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class BrandController : AppControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CompanyAuthorizationService _cmpAuthService;

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


            var brand = await _cmpAuthService.GetBrandAsync(User.Identity.GetUserId(), id);
            var brandImage = await _unitOfWork.ImageRepository.FindByIdAsync(brand.ImageId);

            var model = new BrandOverviewViewModel()
            {
                Id = brand.Id,
                Name = brand.Name,
                ShortDescription = brand.ShortDescription,
                Description = brand.Description,
                MainHexColor = brand.MainHexColor,
                Image = new BrandImageViewModel()
                {
                    Id = brandImage.Id,
                    Name = Path.Combine(Server.MapPath("SharedStorage/BrandImages"), brandImage.Name)
                }
            };

            return View(model);


        }



        public ActionResult Colors(int id)
        {
            ViewBag.BrandId = id;

            if (!_cmpAuthService.IsAuthorized(User.Identity.GetUserId(), id))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }


            var categories = _unitOfWork.ColorCategoryRepository.GetCategoriesForBrand(id);

            var model = new ColorsViewModel
            {
                Categories = new List<ColorCategoryViewModel>()
            };


            foreach (var category in categories)
            {
                var colors = _unitOfWork.ColorRepository.GetAllColorsFromCategory(category.Id);

                var singleColors = new List<SingleColorViewModel>();

                foreach (var color in colors)
                {
                    var plainColor = System.Drawing.ColorTranslator.FromHtml("#" + color.HexColorCode);
                    var rgb = "" + plainColor.R + ", " + plainColor.G + ", " + plainColor.B;

                    singleColors.Add(new SingleColorViewModel()
                    {
                        Name = color.Name,
                        HexColor = color.HexColorCode,
                        RgbValue = rgb,
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
            ViewBag.BrandId = id;

            if (!_cmpAuthService.IsAuthorized(User.Identity.GetUserId(), id))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }


            return View();
        }

        public ActionResult Icons(int id)
        {
            ViewBag.BrandId = id;

            if (!_cmpAuthService.IsAuthorized(User.Identity.GetUserId(), id))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }



            var categories = _unitOfWork.IconCategoryRepository.GetCategoriesForBrand(id);

            var model = new IconsViewModel
            {
                Categories = new List<IconCategoryViewModel>()
            };


            foreach (var category in categories)
            {
                var icons = _unitOfWork.IconRepository.GetAllIconsFromCategory(category.Id);

                var singleIcons = new List<SingleIconViewModel>();

                foreach (var icon in icons)
                {

                    singleIcons.Add(new SingleIconViewModel()
                    {
                        ClassName = icon.ClassName,
                        Prefix = icon.Prefix
                    });
                }

                if (singleIcons.Count > 0)
                {
                    model.Categories.Add(new IconCategoryViewModel()
                    {
                        Name = category.Name,
                        Icons = singleIcons

                    });
                }

            }




            return View(model);
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

            var brand = _unitOfWork.BrandRepository.FindById(model.Id);

            brand.Name = model.GeneralSettingsViewModel.Name;
            brand.MainHexColor = model.GeneralSettingsViewModel.MainHexColor;

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
            var brandImage = _unitOfWork.ImageRepository.FindById(brand.ImageId);

            _unitOfWork.BrandRepository.Remove(brand);
            RemoveBrandImage(brandImage);

            _unitOfWork.SaveChanges();


            return RedirectToAction("Overview", "Brands", new { area = "App" });
        }



        private void RemoveBrandImage(Image brandImage)
        {
            var fullPath = Request.MapPath("~/SharedStorage/BrandImages/" + brandImage.Name);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);

                _unitOfWork.ImageRepository.Remove(brandImage);
            }
            else
            {
                throw new FileNotFoundException();
            }

        }


    }
}