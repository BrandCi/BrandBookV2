using System.Threading.Tasks;
using System.Web;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.ViewModels.Process.Notification;
using BrandBook.Core.ViewModels.Process.Notification.TemplateType;
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


        // GET: Auth/ForgotPassword
        public ActionResult ForgotPassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }


        public ActionResult Locked() {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();

        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmAccount(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

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
    }
}