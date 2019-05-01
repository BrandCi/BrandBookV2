using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core;
using BrandBook.Core.RepositoryInterfaces.User;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.User;

namespace BrandBook.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fileds

        private readonly BrandBookDbContext _context;
        private IAppUserRepository _appUserRepository;
        private IUserRoleRepository _userRoleRepository;
        private IRolePermissionRepository _rolePermissionRepository;

        #endregion

        #region Constructor

        public UnitOfWork()
        {
            _context = new BrandBookDbContext();
        }

        #endregion

        #region Member from IUnitOfWork

        public IAppUserRepository AppUserRepository
        {
            get { return _appUserRepository ?? (_appUserRepository = new AppUserRepository(_context)); }
        }

        public IUserRoleRepository UserRoleRepository
        {
            get { return _userRoleRepository ?? (_userRoleRepository = new UserRoleRepository(_context)); }
        }

        public IRolePermissionRepository RolePermissionRepository
        {
            get { return _rolePermissionRepository ?? (_rolePermissionRepository = new RolePermissionRepository(_context)); }
        }





        #endregion

    }
}
