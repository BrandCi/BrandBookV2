using System;
using System.Web.Mvc;
using BrandBook.Core.Repositories.User;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.User;
using log4net;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Framework.Controllers.MvcControllers
{
    [Authorize]
    public class AppMvcControllerBase : MvcControllerBase
    {
        #region Fields
        private readonly IAppUserRepository _appUserRepository;
        #endregion


        public AppMvcControllerBase()
        {
            this._appUserRepository = new AppUserRepository(new BrandBookDbContext());
        }


        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            ViewBag.IsDarkmodeEnabled = _appUserRepository.FindById(User.Identity.GetUserId<int>()).IsDarkmodeEnabled;

            return base.BeginExecuteCore(callback, state);
        }
    }
}
