using BrandBook.Core;
using BrandBook.Core.Domain.Brand;
using BrandBook.Infrastructure;
using log4net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrandBook.Services.Authentication
{
    public class CompanyAuthorizationService
    {

        private readonly IUnitOfWork _unitOfWork;
        protected static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        public CompanyAuthorizationService()
        {
            _unitOfWork = new UnitOfWork();
        }


        public bool IsAuthorized(string appUserGuid, int? id)
        {

            var appUser = _unitOfWork.AppUserRepository.FindById(appUserGuid);

            if (id != null && id != 0)
            {
                var brandId = id ?? 0;

                if (_unitOfWork.BrandRepository.IsBrandExistingById(brandId))
                {
                    var brand = _unitOfWork.BrandRepository.FindById(brandId);

                    if (appUser.CompanyId == brand.CompanyId)
                    {
                        return true;
                    }
                    else
                    {
                        Logger.Warn($"Not authorized to access brand. {{AppUser: #{appUserGuid} | Brand: #{brandId}}}");
                    }
                }
                else
                {
                    Logger.Warn($"Brand does not exist. {{Brand: #{brandId}}}");
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
