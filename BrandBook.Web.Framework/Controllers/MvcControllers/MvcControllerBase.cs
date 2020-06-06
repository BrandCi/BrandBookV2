using BrandBook.Core.Repositories.Setting;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Setting;
using BrandBook.Web.Framework.Helpers;
using log4net;
using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace BrandBook.Web.Framework.Controllers.MvcControllers
{
    public class MvcControllerBase : Controller
    {
        #region Fields
        protected static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        private readonly ISettingRepository _settingRepository;
        #endregion


        public MvcControllerBase()
        {
            this._settingRepository = new SettingRepository(new BrandBookDbContext());
        }


        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {

            ViewBag.MetaAppTitle = _settingRepository.GetSettingByKey("conf_system_apptitle").Value;
            ViewBag.MetaAppAuthor = _settingRepository.GetSettingByKey("conf_system_appauthor").Value;



            string cultureName = null;

            var cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                if (Request.UserLanguages != null && Request.UserLanguages.Length > 0)
                {
                    cultureName = Request.UserLanguages[0];
                }
                else
                {
                    cultureName = null;
                }
            }


            cultureName = CultureHelper.GetImplementedCulture(cultureName);

            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }

    }
}
