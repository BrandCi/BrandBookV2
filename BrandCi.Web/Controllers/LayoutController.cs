using BrandCi.Core;
using BrandCi.Core.ViewModels.Frontend.Layout;
using BrandCi.Infrastructure;
using BrandCi.Web.Framework.Controllers.MvcControllers;
using System.Web.Mvc;

namespace BrandCi.Web.Controllers
{
    public class LayoutController : FrontendMvcControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public LayoutController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        public PartialViewResult GoogleAnalytics()
        {
            var isEnabled = _unitOfWork.SettingRepository.GetSettingByKey("google_analytics_enabled");
            GoogleAnalyticsViewModel model;

            if (isEnabled.Value == "1")
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

        public PartialViewResult UserLike()
        {
            var isEnabled = _unitOfWork.SettingRepository.GetSettingByKey("ext_userlike_enabled");
            UserLikeViewModel model;

            if (isEnabled.Value == "1")
            {
                model = new UserLikeViewModel()
                {
                    IsActive = true,
                    Source = _unitOfWork.SettingRepository.GetSettingByKey("ext_userlike_source").Value
                };
            }
            else
            {
                model = new UserLikeViewModel()
                {
                    IsActive = false,
                    Source = ""
                };
            }

            return PartialView("UserLike", model);
        }

    }
}