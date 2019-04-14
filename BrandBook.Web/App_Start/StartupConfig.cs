using System;
using BrandBook.Infrastructure.Data;
using BrandBook.Services.Authentication;
using BrandBook.Services.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace BrandBook.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(BrandBookDbContext.Create);

        }
    }
}