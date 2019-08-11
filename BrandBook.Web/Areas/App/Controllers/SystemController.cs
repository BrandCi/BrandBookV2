using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Core.Domain.System;
using BrandBook.Infrastructure;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Setting;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Settings;
using BrandBook.Web.Framework.ViewModels.Auth;
using BrandBook.Web.Framework.ViewModels.Frontend.Layout;

namespace BrandBook.Web.Areas.App.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SystemController : AppControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public SystemController()
        {
            this._unitOfWork = new UnitOfWork();
        }


        #region Settings
        // GET: App/Settings
        public ActionResult Settings()
        {
            return View();
        }



        public ActionResult SystemSettings()
        {
            var model = new SystemSettingsViewModel()
            {
                AppTitle = GetSettingValueByKey("conf_system_apptitle"),
                BasicUrl = GetSettingValueByKey("conf_system_baseisurl"),
                EmailAddress = GetSettingValueByKey("conf_system_email")
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SystemSettings(SystemSettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            UpdateSettingValue("conf_system_apptitle", model.AppTitle);
            UpdateSettingValue("conf_system_baseisurl", model.BasicUrl);
            UpdateSettingValue("conf_system_email", model.EmailAddress);
            
            _unitOfWork.SaveChanges();


            return RedirectToAction("SystemSettings", "System", new {area = "App"});


        }



        public ActionResult UserSettings()
        {
            var model = new UserSettingsViewModel()
            {
                Password_ReqLength = GetSettingValueByKey("conf_user_pass_requiredlength"),
                Password_ReqNonLetterOrDigit = GetSettingValueByKey("conf_user_pass_requirenonletterordigit"),
                Password_ReqDigit = GetSettingValueByKey("conf_user_pass_requiredigit"),
                Password_ReqLowerCase = GetSettingValueByKey("conf_user_pass_requirelowercase"),
                Password_ReqUpperCase = GetSettingValueByKey("conf_user_pass_requireuppercase"),
                Lockout_Enabled = GetSettingValueByKey("conf_user_lockout_enable"),
                Lockout_LockoutTime = GetSettingValueByKey("conf_user_lockout_lockouttime"),
                Lockout_FailedAttempts = GetSettingValueByKey("conf_user_lockout_failedattemtsbeforelockout")
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserSettings(UserSettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UpdateSettingValue("conf_user_pass_requiredlength", model.Password_ReqLength);
            UpdateSettingValue("conf_user_pass_requirenonletterordigit", model.Password_ReqNonLetterOrDigit);
            UpdateSettingValue("conf_user_pass_requiredigit", model.Password_ReqDigit);
            UpdateSettingValue("conf_user_pass_requirelowercase", model.Password_ReqLowerCase);
            UpdateSettingValue("conf_user_pass_requireuppercase", model.Password_ReqUpperCase);
            UpdateSettingValue("conf_user_lockout_enable", model.Lockout_Enabled);
            UpdateSettingValue("conf_user_lockout_lockouttime", model.Lockout_LockoutTime);
            UpdateSettingValue("conf_user_lockout_failedattemtsbeforelockout", model.Lockout_FailedAttempts);

            _unitOfWork.SaveChanges();


            return RedirectToAction("UserSettings", "System", new { area = "App" });
        }



        public ActionResult MediaSettings()
        {
            // Media Settings should not be changed via UI.
            // They are part of the initial configuration!
            var model = new MediaSettingsViewModel()
            {
                Key = GetSettingValueByKey("conf_media_key"),
                Server = GetSettingValueByKey("conf_media_server")
            };


            return View(model);
        }

        public ActionResult BrandSettings()
        {
            return View();
        }
        #endregion


        #region Services

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult GoogleAnalytics()
        {
            
            var isActive = false;

            var isEnabled = _unitOfWork.SettingRepository.GetSettingByKey("google_analytics_enabled");

            if (isEnabled.Value == "1")
            {
                isActive = true;
            }

            var trackingKey = _unitOfWork.SettingRepository.GetSettingByKey("google_analytics_trackingkey").Value;


            var model = new GoogleAnalyticsViewModel()
            {
                IsActive = isActive,
                TrackingKey = trackingKey
            };

            

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GoogleAnalytics(GoogleAnalyticsViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.IsActive)
            {
                UpdateSettingValue("google_analytics_enabled", "1");
            }
            else
            {
                UpdateSettingValue("google_analytics_enabled", "0");
            }
            
            UpdateSettingValue("google_analytics_trackingkey", model.TrackingKey);

            _unitOfWork.SaveChanges();


            return RedirectToAction("GoogleAnalytics", "System", new {area = "App"});
        }



        public ActionResult UserLike()
        {

            var isActive = false;

            var isEnabled = _unitOfWork.SettingRepository.GetSettingByKey("ext_userlike_enabled");

            if (isEnabled.Value == "1")
            {
                isActive = true;
            }

            var trackingkey = _unitOfWork.SettingRepository.GetSettingByKey("ext_userlike_source").Value;


            var model = new UserLikeViewModel()
            {
                IsActive = isActive,
                Source = trackingkey
            };



            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLike(UserLikeViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.IsActive)
            {
                UpdateSettingValue("ext_userlike_enabled", "1");
            }
            else
            {
                UpdateSettingValue("ext_userlike_enabled", "0");
            }

            UpdateSettingValue("ext_userlike_source", model.Source);

            _unitOfWork.SaveChanges();


            return RedirectToAction("UserLike", "System", new { area = "App" });
        }

        #endregion


        public ActionResult VersionInfo()
        {
            return View();
        }







        private string GetSettingValueByKey(string settingKey)
        {
            return _unitOfWork.SettingRepository.GetSettingByKey(settingKey).Value;
        }



        private void UpdateSettingValue(string settingKey, string newValue)
        {

            var setting = _unitOfWork.SettingRepository.GetSettingByKey(settingKey);
            setting.Value = newValue;

            _unitOfWork.SettingRepository.Update(setting);


        }

        
    }

}