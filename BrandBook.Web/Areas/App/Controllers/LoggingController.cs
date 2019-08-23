using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.App.Controllers
{
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
          


            
            return View();
        }
    }
}