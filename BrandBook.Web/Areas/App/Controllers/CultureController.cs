using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.Helpers;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class CultureController : AppControllerBase
    {

        public ActionResult Index()
        {
            return View();
        }


        // GET: App/Culture
        public ActionResult SetCulture(string culture)
        {
            culture = CultureHelper.GetImplementedCulture(culture);

            HttpCookie cookie = Request.Cookies["_culture"];

            if (cookie != null)
            {
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }

            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Culture", new { area = "App" });
        }



        public ActionResult ExportTranslationsByCulture()
        {
            return RedirectToAction("Index", "Culture", new {area = "App"});
        }
    }
}