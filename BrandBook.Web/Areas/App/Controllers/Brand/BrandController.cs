using BrandBook.Core;
using BrandBook.Core.Domain.Brand.Color;
using BrandBook.Core.ViewModels.App.Brand;
using BrandBook.Core.ViewModels.App.Brand.Colors;
using BrandBook.Core.ViewModels.App.Brand.Fonts;
using BrandBook.Core.ViewModels.App.Brand.Icons;
using BrandBook.Core.ViewModels.App.Brand.Settings;
using BrandBook.Infrastructure;
using BrandBook.Services.Authentication;
using BrandBook.Services.Subscriptions;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using log4net;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Image = BrandBook.Core.Domain.Resource.Image;

namespace BrandBook.Web.Areas.App.Controllers.Brand
{
    public class BrandController : AppMvcControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CompanyAuthorizationService _cmpAuthService;
        private readonly SubscriptionService _subscriptionService;
        protected static new readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        public BrandController()
        {
            this._unitOfWork = new UnitOfWork();
            this._cmpAuthService = new CompanyAuthorizationService();
            this._subscriptionService = new SubscriptionService();
        }

        // GET: App/Brand
        public async Task<ActionResult> Index(int id)
        {
            var brandId = id;

            ViewBag.BrandId = brandId;

            if (UserIsNotAuthorizedForBrand(brandId))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }


            var brand = await _cmpAuthService.GetBrandAsync(User.Identity.GetUserId<int>(), brandId);
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
                    Name = "/SharedStorage/BrandImages/" + brandImage.Name
                }
            };

            return View(model);


        }



        public ActionResult Colors(int id)
        {
            var brandId = id;
            ViewBag.BrandId = brandId;

            if (UserIsNotAuthorizedForBrand(brandId))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }


            var categories = _unitOfWork.ColorCategoryRepository.GetCategoriesForBrand(brandId);

            var model = new ColorsViewModel
            {
                Categories = new List<ColorCategoryViewModel>(),
                AddColorItem = new AddColorItemViewModel()
                {
                    BrandId = brandId
                }
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
            var brandId = id;
            ViewBag.BrandId = brandId;

            if (UserIsNotAuthorizedForBrand(brandId))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }

            var fonts = _unitOfWork.FontRepository.GetAllFromBrand(brandId);

            var viewModel = new FontsViewModel()
            {
                Fonts = new List<SingleFontViewModel>()
            };

            foreach (var font in fonts)
            {
                var fontInclusion = _unitOfWork.FontInclusionRepository.FindById(font.FontInclusionId);
                var fontStyles = _unitOfWork.FontStyleRepository.GetAllForFont(font.Id);
                var fontStylesViewModel = new List<FontStyleViewModel>();

                foreach (var fontStyle in fontStyles)
                {
                    fontStylesViewModel.Add(new FontStyleViewModel()
                    {
                        Weight = fontStyle.Weight,
                        Style = fontStyle.Style
                    });
                }

                viewModel.Fonts.Add(new SingleFontViewModel()
                {
                    Name = font.Name,
                    Family = font.Family,
                    GoogleFontLink = BuildGoogleFontLink(font.Id),
                    FontInclusion = new FontInclusionViewModel()
                    {
                        HtmlInline = fontInclusion.HtmlInline,
                        CssImport = fontInclusion.CssImport,
                        CssProperty = fontInclusion.CssProperty
                    },
                    FontStyles = fontStylesViewModel
                });

            }


            return View(viewModel);
        }

        public ActionResult Icons(int id)
        {
            var brandId = id;
            ViewBag.BrandId = brandId;

            if (UserIsNotAuthorizedForBrand(brandId))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }



            var categories = _unitOfWork.IconCategoryRepository.GetCategoriesForBrand(brandId);

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
            var brandId = id;
            ViewBag.BrandId = brandId;

            if (UserIsNotAuthorizedForBrand(brandId))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }


            var brand = _unitOfWork.BrandRepository.FindById(brandId);

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
                    ContactPerson = ""
                },

                CustomizingSettingsViewModel = new CustomizingSettingsViewModel()
                {
                    PrimaryHexColor = "",
                    RoundedButtons = true,
                    RoundedButtonsPixel = 5
                }
            };


            return View(model);
        }






        [HttpPost]
        public ActionResult UpdateGeneralSettings(BrandSettingsViewModel model)
        {
            if (!ModelState.IsValid && UserIsNotAuthorizedForBrand(model.Id))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
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
            var brandId = id;

            if (UserIsNotAuthorizedForBrand(brandId))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }

            var brand = _unitOfWork.BrandRepository.FindById(brandId);
            var brandImage = _unitOfWork.ImageRepository.FindById(brand.ImageId);

            _unitOfWork.BrandRepository.Remove(brand);
            RemoveBrandImage(brandImage);

            _unitOfWork.SaveChanges();


            return RedirectToAction("Overview", "Brands", new { area = "App" });
        }



        [HttpPost]
        public ActionResult AddColorItem(AddColorItemViewModel model)
        {

            if (!ModelState.IsValid && UserIsNotAuthorizedForBrand(model.BrandId))
            {
                return RedirectToAction("Overview", "Brands", new { area = "App" });
            }


            var rgbColor = System.Drawing.ColorTranslator.FromHtml("#" + model.HexColor);
            var cmykColor = ConvertRgbToCmyk(rgbColor.R, rgbColor.G, rgbColor.B);


            var color = new Color()
            {
                Name = model.Name,
                Sorting = 1,

                Category = new ColorCategory()
                {
                    BrandId = model.BrandId
                },
                RgbValue = new RgbValue()
                {
                    R = rgbColor.R,
                    G = rgbColor.G,
                    B = rgbColor.B
                },
                CmykValue = new CmykValue()
                {
                    C = cmykColor[0],
                    M = cmykColor[1],
                    Y = cmykColor[2],
                    K = cmykColor[3]
                }

            };

            _unitOfWork.ColorRepository.Add(color);
            _unitOfWork.SaveChanges();


            return RedirectToAction("Colors", "Brand", new { id = model.BrandId, area = "App" });

        }




        private void RemoveBrandImage(Image brandImage)
        {
            // Don't delete the default BrandImage
            if (brandImage.Id == 1)
            {
                return;
            }

            var fullPath = Request.MapPath("~/SharedStorage/BrandImages/" + brandImage.Name);

            if (System.IO.File.Exists(fullPath))
            {
                BackupBrandImage(brandImage);

                _unitOfWork.ImageRepository.Remove(brandImage);

                System.IO.File.Delete(fullPath);
            }
            else
            {
                throw new FileNotFoundException();
            }

        }


        private void BackupBrandImage(Image brandImage)
        {
            var sourcePath = Server.MapPath("/SharedStorage/BrandImages/" + brandImage.Name);
            var backupPath = Server.MapPath("/SharedStorage/_Backup_/BrandImages/" + brandImage.Name);

            System.IO.File.Copy(sourcePath, backupPath);


        }


        private string BuildGoogleFontLink(int fontId)
        {
            var googleFontLink = new StringBuilder();
            googleFontLink.Append("https://fonts.googleapis.com/css?");

            var font = _unitOfWork.FontRepository.FindById(fontId);

            googleFontLink.Append($"family={font.Family}:");

            var fontStyles = _unitOfWork.FontStyleRepository.GetAllForFont(fontId);

            foreach (var fontStyle in fontStyles)
            {
                googleFontLink.Append(fontStyle.Weight);

                if (fontStyle.Style == "italic")
                {
                    googleFontLink.Append("i");
                }

                googleFontLink.Append(",");
            }



            return googleFontLink.ToString();
        }




        private List<int> ConvertRgbToCmyk(int r, int g, int b)
        {
            var cmyk = new List<int>();
            int c, m, y, k;
            float rConvert, gConvert, bConvert;

            rConvert = r / 255F;
            gConvert = g / 255F;
            bConvert = b / 255F;

            k = SaveCmyk(1 - Math.Max(Math.Max(rConvert, gConvert), bConvert));
            c = SaveCmyk((1 - rConvert - k) / (1 - k));
            m = SaveCmyk((1 - gConvert - k) / (1 - k));
            y = SaveCmyk((1 - bConvert - k) / (1 - k));


            cmyk.Add(c);
            cmyk.Add(m);
            cmyk.Add(y);
            cmyk.Add(k);


            return cmyk;

        }



        private int SaveCmyk(float value)
        {
            if (value < 0 || float.IsNaN(value))
            {
                value = 0;
            }

            return (int)Math.Round(value);
        }


        private bool UserIsNotAuthorizedForBrand(int brandId)
        {
            var userId = User.Identity.GetUserId<int>();
            var allowedToAccessBrand = _cmpAuthService.IsAuthorized(userId, brandId) && _subscriptionService.HasValidSubscription(userId);

            if (allowedToAccessBrand)
            {
                return false;
            }

            Logger.Warn($"No valid subscription to view brand. {{AppUser: #{userId} | Brand: #{brandId}}}");

            return true;

        }




    }
}