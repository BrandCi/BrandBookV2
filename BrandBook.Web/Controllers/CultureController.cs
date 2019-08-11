using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.Helpers;

namespace BrandBook.Web.Controllers
{
    public class CultureController : FrontendControllerBase
    {

        public ActionResult SetCulture(string culture, string currentAction, string currentController)
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
            
            return RedirectToAction(currentAction, currentController, new{area = ""});
        }
    }
}