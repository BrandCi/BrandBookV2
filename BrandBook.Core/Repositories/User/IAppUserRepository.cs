using BrandBook.Core.Domain.User;

namespace BrandBook.Core.Repositories.User
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        AppUser FindByUsername(string userName);

        /// <summary>
        /// Automatically updates the LastModified Property
        /// </summary>
        void UpdateWithModification(AppUser user);
    }
}
