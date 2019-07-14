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
        public ActionResult UserOverview()
        {
            return View();
        }


        public async Task<ActionResult> CompanyOverview()
        {

            var allCompanies = await _unitOfWork.CompanyRepository.GetAllAsync();
            List<SingleCompanyViewModel> singleCompanyViewModels = new List<SingleCompanyViewModel>();
            int numberOfUser = 0;

            foreach (Company singleCompany in allCompanies)
            {
                numberOfUser = _unitOfWork.AppUserRepository.CountUserForCompanyId(singleCompany.Id);

                singleCompanyViewModels.Add(new SingleCompanyViewModel()
                {
                    Id = singleCompany.Id,
                    Name = singleCompany.Name,
                    UrlName = singleCompany.UrlName,
                    ContactEmail = singleCompany.ContactEmail,
                    NumberOfUser = numberOfUser

                });
            }


            CompaniesOverviewViewModel viewmodel = new CompaniesOverviewViewModel();
            viewmodel.Companies = singleCompanyViewModels;



            return View(viewmodel);
        }


        public ActionResult RoleOverview()
        {
            return View();
        }
    }
}