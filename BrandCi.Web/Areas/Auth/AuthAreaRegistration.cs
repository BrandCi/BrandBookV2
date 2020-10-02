using System.Web.Mvc;

namespace BrandCi.Web.Areas.Auth
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
                new[] { "BrandCi.Web.Areas.Auth.Controllers" }
            );
            context.MapRoute(
                "ForgotPasswordConfirmation",
                "Auth/ForgotPasswordConfirmation",
                new { controller = "Processes", action = "ForgotPasswordConfirmation" },
                new[] { "BrandCi.Web.Areas.Auth.Controllers" }
            );

            context.MapRoute(
                "ResetPassword",
                "Auth/ResetPassword",
                new { controller = "Processes", action = "ResetPassword" },
                new[] { "BrandCi.Web.Areas.Auth.Controllers" }
            );
            context.MapRoute(
                "ResetPasswordConfirmation",
                "Auth/ResetPasswordConfirmation",
                new { controller = "Processes", action = "ResetPasswordConfirmation" },
                new[] { "BrandCi.Web.Areas.Auth.Controllers" }
            );

            context.MapRoute(
                "UnlockAccount",
                "Auth/Locked",
                new { controller = "Processes", action = "Locked" },
                new[] { "BrandCi.Web.Areas.Auth.Controllers" }
            );






            context.MapRoute(
                "Auth_default",
                "Auth/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}