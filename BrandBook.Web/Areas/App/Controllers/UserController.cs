﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class UserController : AppControllerBase
    {

        private IUnitOfWork _unitOfWork;

        public UserController()
        {
            this._unitOfWork = new UnitOfWork();
        }


        // GET: App/User
        public ActionResult UserOverview()
        {
            return View();
        }


        public ActionResult CompanyOverview()
        {



            return View();
        }
    }
}