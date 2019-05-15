﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core.Domain.System;
using BrandBook.Core.RepositoryInterfaces.Setting;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Setting;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.Settings;
using BrandBook.Web.Framework.ViewModels.Auth;

namespace BrandBook.Web.Areas.App.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SettingsController : AppControllerBase
    {

        private ISettingRepository settingRepository;

        public SettingsController()
        {
            this.settingRepository = new SettingRepository(new BrandBookDbContext());
        }



        // GET: App/Settings
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult System()
        {
            SystemSettingsViewModel model = new SystemSettingsViewModel();

            model.AppTitle = settingRepository.GetSettingByKey("conf_system_apptitle").Value;
            model.BasicUrl = settingRepository.GetSettingByKey("conf_system_baseisurl").Value;
            model.EmailAddress = settingRepository.GetSettingByKey("conf_system_email").Value;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult System(SystemSettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("System", "Settings", new {area = "App"});


        }



        public ActionResult User()
        {
            return View();
        }

        public ActionResult Media()
        {

            MediaSettingsViewModel model = new MediaSettingsViewModel();

            model.Server = settingRepository.GetSettingByKey("conf_media_server").Value;
            model.Key = settingRepository.GetSettingByKey("conf_media_key").Value;


            return View(model);
        }

        public ActionResult Brand()
        {
            return View();
        }
    }
}