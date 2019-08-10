using BrandBook.Core.Domain.User;

namespace BrandBook.Core.Repositories.User
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        AppUser FindByUsername(string username);
        int CountUserForCompanyId(int companyId);
        int GetCompanyIdByUsername(string username);
    }
}
