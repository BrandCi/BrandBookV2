using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Repository.Brand;
using BrandBook.Core.Repository.Setting;
using BrandBook.Core.Repository.User;

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

        #endregion



        #region Methods

        void SaveChanges();
        void SaveChangesAsync();

        void Dispose();

        #endregion
    }
}
