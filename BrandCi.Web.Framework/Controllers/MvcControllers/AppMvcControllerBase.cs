using BrandCi.Core.Repositories.User;
using BrandCi.Infrastructure.Data;
using BrandCi.Infrastructure.Repositories.User;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using BrandCi.Core.Domain.User;

namespace BrandCi.Web.Framework.Controllers.MvcControllers
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
            ViewBag.IsDarkmodeEnabled = false;
            ViewBag.IsRegisteredForBetaContent = false;

            if (User.Identity.IsAuthenticated)
            {
                AppUser currentAppUser = _appUserRepository.FindById(User.Identity.GetUserId<int>());

                ViewBag.IsDarkmodeEnabled = currentAppUser.IsDarkmodeEnabled;
                ViewBag.IsRegisteredForBetaContent = currentAppUser.IsRegisteredForBetaContent;
            }


            return base.BeginExecuteCore(callback, state);
        }
    }
}
