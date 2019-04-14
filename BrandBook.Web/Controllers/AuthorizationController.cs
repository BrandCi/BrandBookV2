using System.Threading.Tasks;
using System.Web.Mvc;
using BrandBook.Core.Domain.User;
using BrandBook.Web.ViewModels.Authorization;

namespace BrandBook.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new User {UserName = model.Username, Email = model.Email};
            }

            return RedirectToAction("Index", "Home");
        }
    }
}