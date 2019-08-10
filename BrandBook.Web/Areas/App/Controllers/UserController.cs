using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core;
using BrandBook.Core.Domain.Company;
using BrandBook.Infrastructure;
using BrandBook.Web.Framework.Controllers;
using BrandBook.Web.Framework.ViewModels.App.UserManagement;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class UserController : AppControllerBase
    {

        private IUnitOfWork _unitOfWork;

        public UserController()
        {
            this._unitOfWork = new UnitOfWork();
        }


        // GET: App/User
        public async Task<ActionResult> UserOverview()
        {

            var allAppUsers = await _unitOfWork.AppUserRepository.GetAllAsync();


            return View();
        }


        public async Task<ActionResult> CompanyOverview()
        {

            var allCompanies = await _unitOfWork.CompanyRepository.GetAllAsync();
            var singleCompanyViewModels = new List<SingleCompanyViewModel>();

            foreach (Company singleCompany in allCompanies)
            {
                var numberOfUser = _unitOfWork.AppUserRepository.CountUserForCompanyId(singleCompany.Id);

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