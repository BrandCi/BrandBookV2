using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Controllers
{
    public class LayoutController : FrontendControllerBase
    {

        private IUnitOfWork _unitOfWork;

        public LayoutController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        public PartialViewResult GoogleAnalytics()
        {
            return PartialView("GoogleAnalytics");
        }

    }
}