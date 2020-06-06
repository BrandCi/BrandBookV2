using log4net;
using System.Web.Http;

namespace BrandBook.Web.Framework.Controllers.ApiControllers
{
    public class ApiControllerBase : ApiController
    {
        protected static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
    }
}
