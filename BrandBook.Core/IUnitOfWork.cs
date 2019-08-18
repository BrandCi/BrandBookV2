using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Repositories.Brand;
using BrandBook.Core.Repositories.Company;
using BrandBook.Core.Repositories.Resource;
using BrandBook.Core.Repositories.Setting;
using BrandBook.Core.Repositories.User;

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
        
        #endregion



        #region Methods

        void SaveChanges();
        void SaveChangesAsync();

        new void Dispose();

        #endregion
    }
}
