using BrandCi.Core.ViewModels.App.Settings;
using BrandCi.Web.Framework.Controllers.MvcControllers;
using BrandCi.Web.Framework.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrandCi.Web.Areas.App.Controllers
{
    public class AppCultureController : AppMvcControllerBase
    {
        #region Actions
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
        #endregion


        #region Public Methods
        public FileResult ExportTranslationsByCulture(AppCultureViewModel model)
        {
            var translationName = GenerateTranslationExportName();
            GenerateAndSaveTranslationFile(translationName);

            return File(GetAbsoluteFilePath(translationName), "csv");

            // return RedirectToAction("Index", "AppCulture", new {area = "App"});
        }
        #endregion


        #region Helper Methods
        private void GenerateAndSaveTranslationFile(string translationName)
        {
            var csv = string.Join(
                Environment.NewLine,
                LoadListOfTranslations().Select(d => d.Key + ";" + d.Value + ";")
            );

            System.IO.File.WriteAllText(GetAbsoluteFilePath(translationName), csv);

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
        #endregion 
    }
}