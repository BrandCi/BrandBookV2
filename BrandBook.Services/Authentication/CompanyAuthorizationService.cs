using System;
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


        public Task<Brand> GetBrandAsync(int AppUserId, int BrandId)
        {

            


        }


    }
}
