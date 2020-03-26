using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using BrandBook.Core.Domain.Frontend;
using BrandBook.Core.Dto.Frontend.Blog;
using BrandBook.Core.Services.Authentication;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.ViewModels.Frontend.Support;
using BrandBook.Resources;
using BrandBook.Web.Framework.Controllers.ApiControllers;

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

        [Route("send")]
        public async Task<IHttpActionResult> Send([FromBody] ContactFormViewModel model)
        {
            if (_recaptchaService.IsCaptchaActive())
            {
                var isCaptchaValid = await _recaptchaService.IsCaptchaValid(model.ReCaptchaToken, HttpContext.Current.Request.UserHostAddress, "frontend_contact");
                if (!isCaptchaValid)
                {
                    return BadRequest();
                }
            }

            var message = new StringBuilder();

            message.Append("<strong>Name:</strong> " + model.Name + "<br />");
            message.Append("<strong>Email:</strong> " + model.Email + "<br />");
            message.Append("<strong>Subject:</strong> " + model.Subject + "<br />");
            message.Append("<strong>Message:</strong> " + model.Message);

            _notificationService.SendNotification("brandci@philipp-moser.de", "Contact Request - BrandCi",
                message.ToString());

            return Ok();
        }
    }
}
