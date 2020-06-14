﻿using BrandBook.Core;
using BrandBook.Core.Domain.Brand;
using BrandBook.Infrastructure;
using log4net;
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


        public bool IsAuthorized(int appUserId, int? id)
        {

            var appUser = _unitOfWork.AppUserRepository.FindById(appUserId);

            // TODO: UnitTest
            var idIsNotNull = id != null && id != 0;

            if (idIsNotNull)
            {
                var brandId = id ?? 0;

                if (_unitOfWork.BrandRepository.IsBrandExistingById(brandId))
                {
                    var brand = _unitOfWork.BrandRepository.FindById(brandId);

                    if (_unitOfWork.CompanyMembershipRepository.GetCompanyIdByUserId(appUser.Id) == brand.CompanyId)
                    {
                        return true;
                    }
                    else
                    {
                        Logger.Warn($"Not authorized to access brand. {{AppUser: {appUser.UserName} | Brand: #{brandId}}}");
                    }
                }
                else
                {
                    Logger.Warn($"Brand does not exist. {{Brand: #{brandId}}}");
                }

            }

            return false;
        }


        public async Task<Brand> GetBrandAsync(int appUserId, int? brandId)
        {
            if (IsAuthorized(appUserId, brandId))
            {
                return await _unitOfWork.BrandRepository.FindByIdAsync(brandId);
            }

            return new Brand();

        }
    }
}