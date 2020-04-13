using BrandBook.Core.Domain.User;

namespace BrandBook.Core.Repositories.User
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        AppUser FindByUsername(string userName);
        int CountUserForCompanyId(int companyId);
        int GetCompanyIdByUsername(string userName);
        int GetCompanyIdByUserId(int userId);
    }
}
