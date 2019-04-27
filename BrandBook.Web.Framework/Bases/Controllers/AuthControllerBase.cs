using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BrandBook.Services.Authentication;
using BrandBook.Services.Users;

namespace BrandBook.Web.Framework.Bases.Controllers
{
    public class AuthControllerBase : Controller
    {

        #region Fields

        public SignInService _signInService;
        public UserService _userService;

        #endregion




    }
}
