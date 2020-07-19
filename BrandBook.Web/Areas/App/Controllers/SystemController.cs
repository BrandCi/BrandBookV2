using BrandBook.Core;
using BrandBook.Core.Services;
using BrandBook.Core.ViewModels.App.Settings;
using BrandBook.Core.ViewModels.Frontend.Layout;
using BrandBook.Infrastructure;
using BrandBook.Services;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.App.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SystemController : AppMvcControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISettingService _settingService;
        #endregion


        #region Constructor
        public SystemController()
        {
            this._unitOfWork = new UnitOfWork();
            _settingService = new SettingService();
        }
        #endregion


        #region Actions
        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult SystemSettings()
        {
            var model = new SystemSettingsViewModel()
            {
                AppTitle = _settingService.GetSettingValueByKey("conf_system_apptitle"),
                BasicUrl = _settingService.GetSettingValueByKey("conf_system_baseisurl"),
                EmailAddress = _settingService.GetSettingValueByKey("conf_system_email")
            };

            return View(model);
        }

        public ActionResult UserSettings()
        {
            var model = new UserSettingsViewModel()
            {
                Password_ReqLength = _settingService.GetSettingValueByKey("conf_user_pass_requiredlength"),
                Password_ReqNonLetterOrDigit = _settingService.GetSettingValueByKey("conf_user_pass_requirenonletterordigit"),
                Password_ReqDigit = _settingService.GetSettingValueByKey("conf_user_pass_requiredigit"),
                Password_ReqLowerCase = _settingService.GetSettingValueByKey("conf_user_pass_requirelowercase"),
                Password_ReqUpperCase = _settingService.GetSettingValueByKey("conf_user_pass_requireuppercase"),
                Lockout_Enabled = _settingService.GetSettingValueByKey("conf_user_lockout_enable"),
                Lockout_LockoutTime = _settingService.GetSettingValueByKey("conf_user_lockout_lockouttime"),
                Lockout_FailedAttempts = _settingService.GetSettingValueByKey("conf_user_lockout_failedattemtsbeforelockout")
            };

            return View(model);
        }

        public ActionResult MediaSettings()
        {
            var model = new MediaSettingsViewModel()
            {
                Server = ConfigurationManager.AppSettings["CdnServerUrl"],
                Key = ConfigurationManager.AppSettings["CdnServerKey"]
            };

            return View(model);
        }

        public ActionResult BrandSettings()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult GoogleAnalytics()
        {

            var isActive = false;

            var isEnabled = _settingService.GetSettingValueByKey("google_analytics_enabled");

            if (isEnabled == "1")
            {
                isActive = true;
            }

            var trackingKey = _settingService.GetSettingValueByKey("google_analytics_trackingkey");


            var model = new GoogleAnalyticsViewModel()
            {
                IsActive = isActive,
                TrackingKey = trackingKey
            };



            return View(model);
        }

        public ActionResult UserLike()
        {

            var isActive = false;

            var isEnabled = _settingService.GetSettingValueByKey("ext_userlike_enabled");

            if (isEnabled == "1")
            {
                isActive = true;
            }

            var trackingKey = _settingService.GetSettingValueByKey("ext_userlike_source");


            var model = new UserLikeViewModel()
            {
                IsActive = isActive,
                Source = trackingKey
            };



            return View(model);
        }

        public ActionResult VersionInfo()
        {
            return View();
        }
        #endregion


        #region Public POST Actions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLike(UserLikeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var settingUpdateDictionary = new Dictionary<string, string>()
            {
                {"ext_userlike_enabled", model.IsActive ? "1" : "0"},
                {"ext_userlike_source", model.Source}
            };

            _settingService.UpdateSettingsValue(settingUpdateDictionary);


            return RedirectToAction("UserLike", "System", new { area = "App" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GoogleAnalytics(GoogleAnalyticsViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var settingUpdateDictionary = new Dictionary<string, string>()
            {
                {"google_analytics_enabled", model.IsActive ? "1" : "0"},
                {"google_analytics_trackingkey", model.TrackingKey}
            };

            _settingService.UpdateSettingsValue(settingUpdateDictionary);

            return RedirectToAction("GoogleAnalytics", "System", new { area = "App" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserSettings(UserSettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var settingUpdateDictionary = new Dictionary<string, string>
            {
                {"conf_user_pass_requiredlength", model.Password_ReqLength},
                {"conf_user_pass_requirenonletterordigit", model.Password_ReqNonLetterOrDigit},
                {"conf_user_pass_requiredigit", model.Password_ReqDigit},
                {"conf_user_pass_requirelowercase", model.Password_ReqLowerCase},
                {"conf_user_pass_requireuppercase", model.Password_ReqUpperCase},
                {"conf_user_lockout_enable", model.Lockout_Enabled},
                {"conf_user_lockout_lockouttime", model.Lockout_LockoutTime},
                {"conf_user_lockout_failedattemtsbeforelockout", model.Lockout_FailedAttempts}
            };

            _settingService.UpdateSettingsValue(settingUpdateDictionary);

            return RedirectToAction("UserSettings", "System", new { area = "App" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SystemSettings(SystemSettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var settingUpdateDictionary = new Dictionary<string, string>()
            {
                {"conf_system_apptitle", model.AppTitle},
                {"conf_system_baseisurl", model.BasicUrl},
                {"conf_system_email", model.EmailAddress}
            };

            _settingService.UpdateSettingsValue(settingUpdateDictionary);

            return RedirectToAction("SystemSettings", "System", new { area = "App" });


        }
        #endregion

    }

}