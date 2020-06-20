using BrandBook.Core.Services.Authentication;
using BrandBook.Core.Services.Messaging;
using BrandBook.Web.Framework.Controllers.ApiControllers;
using System.Web.Http;

namespace BrandBook.Web.Api.v1.Frontend
{
    [RoutePrefix("api/v1/contact")]
    public class ContactsController : FrontendApiControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IReCaptchaService _recaptchaService;

        public ContactsController(
            INotificationService notificationService,
            IReCaptchaService reCaptchaService)
        {
            _notificationService = notificationService;
            _recaptchaService = reCaptchaService;
        }

    }
}
