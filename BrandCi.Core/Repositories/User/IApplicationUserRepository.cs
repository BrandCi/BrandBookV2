using BrandCi.Core.Domain.User;

namespace BrandCi.Core.Repositories.User
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser FindByUsername(string userName);
        int CountUserForCompanyId(int companyId);
        int GetCompanyIdByUsername(string userName);
        int GetCompanyIdByUserId(int userId);

        /// <summary>
        /// Automatically updates the LastModified Property
        /// </summary>
        void UpdateWithModification(ApplicationUser user);
    }
}
