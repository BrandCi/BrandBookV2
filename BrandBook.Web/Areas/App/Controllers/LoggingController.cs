using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.System.LoggingMessages;

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
        public async Task<ActionResult> LoggingMessages()
        {

            var loggingMessages = await _unitOfWork.Log4NetLogRepository.GetAllAsync();

            var viewModel = new LoggingMessagesViewModel()
            {
                LoggingMessages = new List<SingleLoggingMessageViewModel>()
            };

            foreach (var loggingMessage in loggingMessages)
            {
                viewModel.LoggingMessages.Add(new SingleLoggingMessageViewModel()
                {
                    Id = loggingMessage.Id,
                    Date = loggingMessage.Date,
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