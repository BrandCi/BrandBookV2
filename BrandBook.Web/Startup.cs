using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrandBook.Web.Startup))]
namespace BrandBook.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}