using BrandBook.Core;
using BrandBook.Core.Domain.System.Notification;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.ViewModels.Auth.Process;
using BrandBook.Core.ViewModels.Notification;
using BrandBook.Core.ViewModels.Notification.TemplateType;
using BrandBook.Infrastructure;
using BrandBook.Services.Authentication;
using BrandBook.Services.Notification;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using BrandBook.Web.Framework.Helpers;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.Auth.Controllers
{
    public class ProcessesController : AuthMvcControllerBase
    {
        public UserAuthenticationService _userService;
        private readonly INotificationService _notificationService;
        private readonly IUnitOfWork _unitOfWork;

        public UserAuthenticationService UserManager
        {
            get
            {
                return _userService ?? HttpContext.GetOwinContext().GetUserManager<UserAuthenticationService>();
            }
            private set
            {
                _userService = value;
            }
        }

        public ProcessesController()
        {
            _notificationService = new NotificationService();
            _unitOfWork = new UnitOfWork();
        }


        public ActionResult Locked()
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();

        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmAccount(int userId, string code)
        {
            if (userId == 0 || code == null)
            {
                return View("Error");
            }

            var result = await UserManager.ConfirmEmailAsync(userId, code);

            if (!result.Succeeded)
            {
                return View("Error");
            }

            var user = _unitOfWork.AppUserRepository.FindById(userId);
            var emailTemplate = new EmailTemplateViewModel()
            {
                Type = NotificationTemplateType.User_AccountVerificationConfirmation,
                Receiver = user.Email,
                Subject = "Your Email Verification was successful",
                CreationDate = CustomHelper.GetCurrentDateTimeFormattedForNotification(),
                RequestIp = Request.UserHostAddress,
                User_AccountVerificationConfirmation = new User_AccountVerificationConfirmation()
                {
                    EmailAddress = user.Email
                }
            };

            _notificationService.SendNotification(emailTemplate);

            return View("ConfirmAccount");

        }


        #region ForgotPassword

        // GET: Auth/ForgotPassword
        public ActionResult ForgotPassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await UserManager.FindByNameAsync(model.Username);

            if (user == null || model.Email != user.Email)
            {
                ModelState.AddModelError("User not found", "This user could not be found.");
                return View(model);
            }

            if (!(await UserManager.IsEmailConfirmedAsync(user.Id)))
            {
                ModelState.AddModelError("User not confirmed", "Please confirm your Email.");
                return View(model);
            }


            var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            var targetUrl = Url.Action("ResetPassword", "Processes", new { area = "Auth", userId = user.Id, code }, protocol: Request.Url.Scheme);


            var email = new EmailTemplateViewModel()
            {
                Type = NotificationTemplateType.User_AccountForgotPassword,
                Subject = "Password reset request",
                Receiver = user.Email,
                CreationDate = CustomHelper.GetCurrentDateTimeFormattedForNotification(),
                RequestIp = Request.UserHostAddress,
                User_AccountForgotPassword = new User_AccountForgotPassword()
                {
                    TargetUrl = targetUrl
                }
            };

            _notificationService.SendNotification(email);

            return RedirectToAction("ForgotPasswordConfirmation", "Processes", new { area = "Auth" });

        }

        public ActionResult ForgotPasswordConfirmation()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }


        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await UserManager.FindByNameAsync(model.Username);

            if (user == null || string.IsNullOrEmpty(model.Code))
            {
                return View("Error");
            }


            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Could not be saved", "Your password could not be saved. Please try again.");
                return View(model);
            }


            var email = new EmailTemplateViewModel()
            {
                Type = NotificationTemplateType.User_AccountForgotPasswordConfirmation,
                Subject = "Password successfully changed",
                Receiver = user.Email,
                CreationDate = CustomHelper.GetCurrentDateTimeFormattedForNotification(),
                RequestIp = Request.UserHostAddress,
                User_AccountForgotPasswordConfirmation = new User_AccountForgotPasswordConfirmation()
            };

            _notificationService.SendNotification(email);

            return RedirectToAction("ResetPasswordConfirmation", "Processes", new { area = "Auth" });

        }

        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        #endregion
    }
}