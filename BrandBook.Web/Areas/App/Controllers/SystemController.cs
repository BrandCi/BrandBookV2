using System;
using System.Collections.Generic;
using System.Linq;
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
        private IUnitOfWork unitOfWork;

        public SystemController()
        {
            this.unitOfWork = new UnitOfWork();
        }



        // GET: App/Settings
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult SystemSettings()
        {
            SystemSettingsViewModel model = new SystemSettingsViewModel();

            model.AppTitle = unitOfWork.SettingRepository.GetSettingByKey("conf_system_apptitle").Value;
            model.BasicUrl = unitOfWork.SettingRepository.GetSettingByKey("conf_system_baseisurl").Value;
            model.EmailAddress = unitOfWork.SettingRepository.GetSettingByKey("conf_system_email").Value;

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

            return RedirectToAction("SystemSettings", "System", new {area = "App"});


        }



        public ActionResult UserSettings()
        {
            return View();
        }

        public ActionResult MediaSettings()
        {

            MediaSettingsViewModel model = new MediaSettingsViewModel();

            model.Server = unitOfWork.SettingRepository.GetSettingByKey("conf_media_server").Value;
            model.Key = unitOfWork.SettingRepository.GetSettingByKey("conf_media_key").Value;


            return View(model);
        }

        public ActionResult BrandSettings()
        {
            return View();
        }
    }
}