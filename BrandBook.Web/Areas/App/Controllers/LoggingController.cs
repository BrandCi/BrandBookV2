using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Core.ViewModels.App.System.LoggingMessages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.App.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LoggingController : AppControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public LoggingController()
        {
            _unitOfWork = new UnitOfWork();
        }



        // GET: App/Logging
        public ActionResult LoggingMessages()
        {

            var loggingMessages = _unitOfWork.Log4NetLogRepository.GetAll().OrderBy(m => m.Date);

            var viewModel = new LoggingMessagesViewModel()
            {
                LoggingMessages = new List<SingleLoggingMessageViewModel>()
            };

            foreach (var loggingMessage in loggingMessages)
            {
                viewModel.LoggingMessages.Add(new SingleLoggingMessageViewModel()
                {
                    Id = loggingMessage.Id,
                    Date = loggingMessage.Date.ToString("dd.MM.yyyy HH:mm:ss"),
                    Logger = loggingMessage.Logger,
                    Level = loggingMessage.Level,
                    Thread = loggingMessage.Thread,
                    Message = loggingMessage.Message,
                    Exception = loggingMessage.Exception
                });
            }


            return View(viewModel);
        }
    }
}