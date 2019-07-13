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
            SystemSettingsViewModel model = new SystemSettingsViewModel()
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
            UserSettingsViewModel model = new UserSettingsViewModel()
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

        public ActionResult MediaSettings()
        {
            // Media Settings should not be changed via UI.
            // They are part of the initial configuration!
            MediaSettingsViewModel model = new MediaSettingsViewModel()
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