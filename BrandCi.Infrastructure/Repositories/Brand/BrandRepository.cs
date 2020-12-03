﻿using BrandCi.Core.Repositories.Brand;
using BrandCi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandCi.Infrastructure.Repositories.Brand
{
    public class BrandRepository : Repository<Core.Domain.Brand.Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context)
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


        public int CountBrandsByCompany(int companyId)
        {
            return Set.Count(b => b.Company.Id == companyId);
        }

    }
}
