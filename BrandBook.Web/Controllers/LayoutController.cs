using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.Frontend.Layout;

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
            var ga_enabled = _unitOfWork.SettingRepository.GetSettingByKey("google_analytics_enabled");
            GoogleAnalyticsViewModel model;

            if (ga_enabled.Value == "1")
            {
                model = new GoogleAnalyticsViewModel()
                {
                    IsActive = true,
                    TrackingKey = _unitOfWork.SettingRepository.GetSettingByKey("google_analytics_trackingkey").Value
                };
            }
            else
            {
                model = new GoogleAnalyticsViewModel()
                {
                    IsActive = false,
                    TrackingKey = ""
                };
            }

            

            return PartialView("GoogleAnalytics", model);
        }

    }
}