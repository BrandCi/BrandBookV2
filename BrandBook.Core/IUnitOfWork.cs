using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.RepositoryInterfaces.User;

namespace BrandBook.Core
{
    public interface IUnitOfWork : IDisposable
    {

        #region Fileds
        IAppUserRepository UserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IRolePermissionRepository RolePermissionRepository { get; }
        #endregion



        #region Methods

        int SaveChanges();
        Task<int> SaveChangesAsync();

        #endregion
    }
}
