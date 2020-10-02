using BrandCi.Core.Domain.User;

namespace BrandCi.Core.Repositories.User
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        AppUser FindByUsername(string userName);
        int CountUserForCompanyId(int companyId);
        int GetCompanyIdByUsername(string userName);
        int GetCompanyIdByUserId(int userId);

        /// <summary>
        /// Automatically updates the LastModified Property
        /// </summary>
        void UpdateWithModification(AppUser user);
    }
}
