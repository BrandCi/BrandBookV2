using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core;
using BrandBook.Core.Domain.Brand;
using BrandBook.Core.Domain.Company;
using BrandBook.Infrastructure;

namespace BrandBook.Services.Authentication
{
    public class CompanyAuthorizationService
    {

        private IUnitOfWork _unitOfWork;

        public CompanyAuthorizationService()
        {
            this._unitOfWork = new UnitOfWork();
        }


        public async Task<bool> IsAuthorized(string appUserGuid, int brandId)
        {

            var appUser = await _unitOfWork.AppUserRepository.FindByIdAsync(appUserGuid);
            var brand = await _unitOfWork.BrandRepository.FindByIdAsync(brandId);

            if (appUser.Company.Id == brand.Company.Id)
            {
                return true;
            }

            return false;
        }


        public async Task<Brand> GetBrandAsync(string appUserGuid, int brandId)
        {
            if (await IsAuthorized(appUserGuid, brandId))
            {
                return await _unitOfWork.BrandRepository.FindByIdAsync(brandId);
            }

            return new Brand();

        }


        public async Task<List<Brand>> GetAllBrandsAsync(string AppUserId)
        {

            var appUser = await _unitOfWork.AppUserRepository.FindByIdAsync(AppUserId);

            return await _unitOfWork.BrandRepository.GetBrandsByCompanyAsync(appUser.Company.Id);

        }


    }
}
