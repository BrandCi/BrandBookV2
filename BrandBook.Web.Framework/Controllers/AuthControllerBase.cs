using System.Web.Mvc;
using BrandBook.Services.Authentication;
using BrandBook.Services.Users;

namespace BrandBook.Web.Framework.Controllers
{
    public class AuthControllerBase : BaseController
    {

        #region Fields

        public SignInService _signInService;
        public UserService _userService;

        #endregion




    }
}
