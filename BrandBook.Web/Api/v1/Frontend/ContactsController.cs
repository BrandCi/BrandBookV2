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

        [HttpPost]
        [Route("send")]
        public async Task<IHttpActionResult> Send([FromBody] ContactFormViewModel model)
        {
            return BadRequest();
        }
    }
}
