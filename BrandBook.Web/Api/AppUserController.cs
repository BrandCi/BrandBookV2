using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrandBook.Core.RepositoryInterfaces.User;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.User;

namespace BrandBook.Web.Api
{
    public class AppUserController : ApiController
    {

        private IAppUserRepository appUserRepository;

        public AppUserController()
        {
            this.appUserRepository = new AppUserRepository(new BrandBookDbContext());
        }

    }
}
