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


        public bool IsAuthorized(string appUserGuid, int? id)
        {

            var appUser = _unitOfWork.AppUserRepository.FindById(appUserGuid);

            if (id != null && id != 0)
            {
                int brandId = id ?? 0;

                if (_unitOfWork.BrandRepository.IsBrandExistingById(brandId))
                {
                    var brand = _unitOfWork.BrandRepository.FindById(brandId);

                    if (appUser.CompanyId == brand.CompanyId)
                    {
                        return true;
                    }
                }
                
            }

            return false;
        }


        public async Task<Brand> GetBrandAsync(string appUserGuid, int? brandId)
        {
            if (IsAuthorized(appUserGuid, brandId))
            {
                return await _unitOfWork.BrandRepository.FindByIdAsync(brandId);
            }

            return new Brand();

        }


        public async Task<List<Brand>> GetAllBrandsAsync(string appUserId)
        {

            var appUser = await _unitOfWork.AppUserRepository.FindByIdAsync(appUserId);

            return await _unitOfWork.BrandRepository.GetBrandsByCompanyAsync(appUser.CompanyId);

        }


    }
}
