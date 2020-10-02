using BrandBook.Core;
using BrandBook.Core.ViewModels.App.System.LoggingMessages;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.App.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LoggingController : AppMvcControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        #region Constructor
        public LoggingController()
        {
            _unitOfWork = new UnitOfWork();
        }
        #endregion


        #region Actions
        public ActionResult LoggingMessages()
        {

            var loggingMessages = _unitOfWork.Log4NetLogRepository.GetAll().OrderByDescending(m => m.Date);

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
        #endregion
    }
}