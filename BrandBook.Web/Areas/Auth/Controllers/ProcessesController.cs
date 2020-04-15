using System.Threading.Tasks;
using System.Web;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.ViewModels.Auth.Process;
using BrandBook.Core.ViewModels.Notification;
using BrandBook.Core.ViewModels.Notification.TemplateType;
using BrandBook.Infrastructure;
using BrandBook.Services.Notification;
using BrandBook.Services.Users;
using Microsoft.AspNet.Identity.Owin;

namespace BrandBook.Web.Areas.Auth.Controllers
{
    public class ProcessesController : AuthMvcControllerBase
    {
        public UserService _userService;
        private readonly INotificationService _notificationService;
        private readonly IUnitOfWork _unitOfWork;

        public UserService UserManager
        {
            get
            {
                return _userService ?? HttpContext.GetOwinContext().GetUserManager<UserService>();
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
        

        public ActionResult Locked() {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();

        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmAccount(int userId, string code)
        {
            if (userId == 0 || code == null) return View("Error");


            var result = await UserManager.ConfirmEmailAsync(userId, code);

            if (!result.Succeeded) return View("Error");


            var user = _unitOfWork.AppUserRepository.FindById(userId);
            var emailTemplate = new EmailTemplateViewModel()
            {
                Type = EmailTemplateType.User_AccountVerificationConfirmation,
                Receiver = user.Email,
                Subject = "Your Email Verification was successful",
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
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home", new { area = "" });

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    return View("ForgotPasswordConfirmation");
                }
                
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                return RedirectToAction("ForgotPasswordConfirmation", "Processes", new { area = "Auth" });
            }

            return View(model);
        }

        public ActionResult ForgotPasswordConfirmation()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home", new { area = "" });

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

            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Processes", new { area = "Auth" });
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Processes", new { area = "Auth" });
            }
            
            return View();
        }

        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        #endregion
    }
}