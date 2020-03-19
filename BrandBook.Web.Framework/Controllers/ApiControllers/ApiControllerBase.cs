using System.Web.Http;
using log4net;

namespace BrandBook.Web.Framework.Controllers.ApiControllers
{
    public class ApiControllerBase : ApiController
    {
        protected static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
    }
}
