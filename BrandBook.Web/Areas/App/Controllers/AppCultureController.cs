using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.Helpers;
using BrandBook.Web.Framework.ViewModels.App.Settings;
using Exception = System.Exception;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class AppCultureController : AppControllerBase
    {

        public ActionResult Index()
        {
            var amountOfTranslations = LoadListOfTranslations().Count;

            var viewModel = new AppCultureViewModel()
            {
                AmountOfTranslations = amountOfTranslations,
                SelectedCultureForExport = "en-US"
            };

            return View();
        }


        // GET: App/Culture
        public ActionResult SetCulture(string culture)
        {
            culture = CultureHelper.GetImplementedCulture(culture);

            var cookie = Request.Cookies["_culture"];

            if (cookie != null)
            {
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            else
            {
                cookie = new HttpCookie("_culture")
                {
                    Value = culture,
                    Expires = DateTime.Now.AddYears(1)
                };
            }

            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "AppCulture", new { area = "App" });
        }



        public FileResult ExportTranslationsByCulture(AppCultureViewModel model)
        {
            var translationName = GenerateTranslationExportName();
            GenerateAndSaveTranslationFile(translationName);

            return File(GetAbsoluteFilePath(translationName), "csv");

            // return RedirectToAction("Index", "AppCulture", new {area = "App"});
        }


        private void GenerateAndSaveTranslationFile(string translationName)
        {
            var csv = String.Join(
                Environment.NewLine,
                LoadListOfTranslations().Select(d => d.Key + ";" + d.Value + ";")
            );
            
            try
            {
                System.IO.File.WriteAllText(GetAbsoluteFilePath(translationName), csv);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }



        private Dictionary<string, string> LoadListOfTranslations()
        {
            var keyValuePairs = new Dictionary<string, string>();

            var resourceSet = Resources
                                .Translations
                                .ResourceManager
                                .GetResourceSet(
                                    CultureInfo.CreateSpecificCulture("en-US"),
                                    false,
                                    true);
            
            foreach (DictionaryEntry item in resourceSet)
            {
                keyValuePairs.Add(item.Key.ToString(), item.Value.ToString());
            }

            return keyValuePairs;

        }


        private string GenerateTranslationExportName()
        {
            var currentDate = DateTime.Now;

            return currentDate.ToString("yyymmdd-hhmmss") + "_Translations.csv";
        }

        private string GetAbsoluteFilePath(string translationName)
        {
            var folder = Server.MapPath("/SharedStorage/Translations/");

            return Path.Combine(folder, translationName);
        }
    }
}