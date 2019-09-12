using BrandBook.Core.Repositories.Brand;
using BrandBook.Core.Repositories.Company;
using BrandBook.Core.Repositories.Resource;
using BrandBook.Core.Repositories.Setting;
using BrandBook.Core.Repositories.System;
using BrandBook.Core.Repositories.User;
using System;

namespace BrandBook.Core
{
    public interface IUnitOfWork : IDisposable
    {

        #region Fileds

        IAppUserRepository AppUserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IRolePermissionRepository RolePermissionRepository { get; }
        ISettingRepository SettingRepository { get; }
        IBrandRepository BrandRepository { get; }
        IColorRepository ColorRepository { get; }
        IColorCategoryRepository ColorCategoryRepository { get; }
        IFontRepository FontRepository { get; }
        IIconRepository IconRepository { get; }
        IIconCategoryRepository IconCategoryRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IImageRepository ImageRepository { get; }
        ISubscriptionRepository SubscriptionRepository { get; }
        ISubscriptionPlanRepository SubscriptionPlanRepository { get; }
        ILog4NetLogRepository Log4NetLogRepository { get; }

        #endregion



        #region Methods

        void SaveChanges();
        void SaveChangesAsync();

        new void Dispose();

        #endregion
    }
}
