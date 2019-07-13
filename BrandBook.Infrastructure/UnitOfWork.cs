﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core;
using BrandBook.Core.Repositories.Brand;
using BrandBook.Core.Repositories.Company;
using BrandBook.Core.Repositories.Setting;
using BrandBook.Core.Repositories.User;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Brand;
using BrandBook.Infrastructure.Repositories.Company;
using BrandBook.Infrastructure.Repositories.Setting;
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
        private ISettingRepository _settingRepository;
        private IBrandRepository _brandRepository;
        private IColorRepository _colorRepository;
        private IColorCategoryRepository _colorCategoryRepository;
        private IFontRepository _fontRepository;
        private ICompanyRepository _companyRepository;

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

        public ISettingRepository SettingRepository
        {
            get { return _settingRepository ?? (_settingRepository = new SettingRepository(_context)); }
        }

        public IBrandRepository BrandRepository
        {
            get { return _brandRepository ?? (_brandRepository = new BrandRepository(_context)); }
        }

        public IColorRepository ColorRepository
        {
            get { return _colorRepository ?? (_colorRepository = new ColorRepository(_context)); }
        }

        public IColorCategoryRepository ColorCategoryRepository
        {
            get { return _colorCategoryRepository ?? (_colorCategoryRepository = new ColorCategoryRepository(_context)); }
        }

        public IFontRepository FontRepository
        {
            get { return _fontRepository ?? (_fontRepository = new FontRepository(_context)); }
        }

        public ICompanyRepository CompanyRepository
        {
            get { return _companyRepository ?? (_companyRepository = new CompanyRepository(_context)); }
        }




        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        #endregion


        #region IDisposable Member

        public void Dispose()
        {
            _appUserRepository = null;
            _userRoleRepository = null;
            _rolePermissionRepository = null;
            _settingRepository = null;
            _brandRepository = null;
            _colorRepository = null;
            _colorCategoryRepository = null;
            _fontRepository = null;
            _companyRepository = null;

            _context.Dispose();
        }

        #endregion

    }
}
