using System.Web.Mvc;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.Auth.Controllers
{
    public class ForgotPasswordController : AuthControllerBase
    {
        // GET: Auth/ForgotPassword
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }
    }
}