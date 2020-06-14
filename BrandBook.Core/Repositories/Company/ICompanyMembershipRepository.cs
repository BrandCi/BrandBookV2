using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Company;

namespace BrandBook.Core.Repositories.Company
{
    public interface ICompanyMembershipRepository : IRepository<CompanyMembership>
    {
        int GetAmountOfUsersForCompany(int companyId);
        int GetAmountOfManagersForCompany(int companyId);
        int GetCompanyIdByUserId(int userId);
    }
}
