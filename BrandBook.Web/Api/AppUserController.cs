using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BrandBook.Core.Domain.Brand;
using BrandBook.Core.Domain.User;
using BrandBook.Core.Dtos.Brand;
using BrandBook.Core.Dtos.User;
using BrandBook.Core.RepositoryInterfaces.User;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.User;

namespace BrandBook.Web.Api
{
    [Authorize]
    public class AppUserController : ApiController
    {

        private IAppUserRepository appUserRepository;

        public AppUserController()
        {
            this.appUserRepository = new AppUserRepository(new BrandBookDbContext());
        }



        public IHttpActionResult GetAppUsers()
        {
            var allAppUser = appUserRepository.GetAll().Select(Mapper.Map<AppUser, AppUserDto>);

            return Ok(allAppUser);
        }

    }
}
