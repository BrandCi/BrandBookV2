using BrandBook.Core;
using BrandBook.Core.ViewModels.App.UserManagement;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers.MvcControllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.App.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserController : AppMvcControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserController()
        {
            this._unitOfWork = new UnitOfWork();
        }


        // GET: App/User
        public async Task<ActionResult> UserOverview()
        {

            var allAppUsers = await _unitOfWork.AppUserRepository.GetAllAsync();
            var singleAppUserViewModel = new List<SingleAppUserViewModel>();

            foreach (var singleAppUser in allAppUsers)
            {
                singleAppUserViewModel.Add(new SingleAppUserViewModel()
                {
                    Id = singleAppUser.Id,
                    Email = singleAppUser.Email,
                    FirstName = singleAppUser.FirstName,
                    LastName = singleAppUser.LastName,
                    UserName = singleAppUser.UserName
                });
            }

            var viewModel = new AppUserViewModel()
            {
                AppUsers = singleAppUserViewModel
            };

            return View(viewModel);
        }


        public async Task<ActionResult> CompanyOverview()
        {

            var allCompanies = await _unitOfWork.CompanyRepository.GetAllAsync();
            var singleCompanyViewModels = new List<SingleCompanyViewModel>();

            foreach (var singleCompany in allCompanies)
            {
                var numberOfUser = _unitOfWork.CompanyMembershipRepository.GetAmountOfUsersForCompany(singleCompany.Id);

                singleCompanyViewModels.Add(new SingleCompanyViewModel()
                {
                    Id = singleCompany.Id,
                    Name = singleCompany.Name,
                    UrlName = singleCompany.UrlName,
                    ContactEmail = singleCompany.ContactEmail,
                    NumberOfUser = numberOfUser

                });
            }


            var viewmodel = new CompaniesOverviewViewModel
            {
                Companies = singleCompanyViewModels
            };



            return View(viewmodel);
        }


        public ActionResult RoleOverview()
        {

            var roles = _unitOfWork.UserRoleRepository.GetAll();

            var model = new RoleOverviewViewModel
            {
                Roles = new List<SingleRoleViewModel>()
            };

            foreach (var role in roles)
            {
                model.Roles.Add(new SingleRoleViewModel()
                {
                    Id = role.Id,
                    Name = role.Name
                });
            }


            return View(model);
        }
    }
}