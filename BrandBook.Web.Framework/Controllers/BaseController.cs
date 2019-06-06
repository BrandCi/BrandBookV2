using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core.Repository.Setting;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Setting;
using BrandBook.Services.Authentication;
using BrandBook.Services.Users;
using BrandBook.Web.Framework.Helpers;

namespace BrandBook.Web.Framework.Controllers
{
    public class BaseController : Controller
    {
        #region Fields

        public SignInService _signInService;
        public UserService _userService;
        public RoleService _roleService;

        #endregion

        private ISettingRepository settingRepository;

        public BaseController()
        {
            this.settingRepository = new SettingRepository(new BrandBookDbContext());
        }


        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {

            ViewBag.AppTitle = settingRepository.GetSettingByKey("conf_system_apptitle").Value;



            string cultureName = null;

            HttpCookie cultureCookie = Request.Cookies["_culture"];
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
