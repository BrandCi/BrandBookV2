using System.Web.Mvc;

namespace BrandBook.Web.Areas.Auth
{
    public class AuthAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Auth";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            /* Auth Processes */
            context.MapRoute(
                "ForgotPassword",
                "Auth/ForgotPassword",
                new { controller = "Processes", action = "ForgotPassword" },
                new[] { "BrandBook.Web.Areas.Auth.Controllers" }
            );

            context.MapRoute(
                "UnlockAccount",
                "Auth/Locked",
                new { controller = "Processes", action = "Locked" },
                new[] { "BrandBook.Web.Areas.Auth.Controllers" }
            );






            context.MapRoute(
                "Auth_default",
                "Auth/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}