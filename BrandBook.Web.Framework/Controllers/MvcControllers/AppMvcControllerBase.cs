using BrandBook.Core.Domain.User;
using BrandBook.Core.Repositories.User;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.User;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

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
