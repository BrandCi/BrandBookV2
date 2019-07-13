﻿using System;
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
            SystemSettingsViewModel model = new SystemSettingsViewModel();

            model.AppTitle = _unitOfWork.SettingRepository.GetSettingByKey("conf_system_apptitle").Value;
            model.BasicUrl = _unitOfWork.SettingRepository.GetSettingByKey("conf_system_baseisurl").Value;
            model.EmailAddress = _unitOfWork.SettingRepository.GetSettingByKey("conf_system_email").Value;

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
            return View();
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