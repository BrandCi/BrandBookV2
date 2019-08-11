using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.Helpers;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class AppCultureController : AppControllerBase
    {

        public ActionResult Index()
        {

            Resources
                .Translations
                .ResourceManager
                .GetResourceSet(
                    CultureInfo.CreateSpecificCulture("de-DE"), 
                    false, 
                    true);




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



        public ActionResult ExportTranslationsByCulture()
        {
            return RedirectToAction("Index", "AppCulture", new {area = "App"});
        }
    }
}