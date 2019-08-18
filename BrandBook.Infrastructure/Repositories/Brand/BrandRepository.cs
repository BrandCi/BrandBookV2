using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Repositories.Brand;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Brand
{
    public class BrandRepository : Repository<Core.Domain.Brand.Brand>, IBrandRepository
    {
        public BrandRepository(BrandBookDbContext context)
            : base(context)
        {
        }


        public List<Core.Domain.Brand.Brand> GetBrandsByCompany(int companyId)
        {
            return Set.Where(b => b.Company.Id == companyId).ToList();
        }


        public async Task<List<Core.Domain.Brand.Brand>> GetBrandsByCompanyAsync(int companyId)
        {
            return await Set.Where(b => b.Company.Id == companyId).ToListAsync();
        }

        public bool IsBrandExistingById(int brandId)
        {
            return Set.Count(b => b.Id == brandId) >= 1;
        }


        public int GetAmountOfBrandsByCompany(int companyId)
        {
            return Set.Count(b => b.Company.Id == companyId);
        }

    }
}
