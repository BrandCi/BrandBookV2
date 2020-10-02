using BrandBook.Core;
using BrandBook.Core.Repositories.Brand;
using BrandBook.Core.Repositories.Brand.Font;
using BrandBook.Core.Repositories.Company;
using BrandBook.Core.Repositories.Frontend;
using BrandBook.Core.Repositories.Resource;
using BrandBook.Core.Repositories.Setting;
using BrandBook.Core.Repositories.System;
using BrandBook.Core.Repositories.User;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Brand;
using BrandBook.Infrastructure.Repositories.Brand.Font;
using BrandBook.Infrastructure.Repositories.Company;
using BrandBook.Infrastructure.Repositories.Frontend;
using BrandBook.Infrastructure.Repositories.Resource;
using BrandBook.Infrastructure.Repositories.Setting;
using BrandBook.Infrastructure.Repositories.System;
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
        private IFontInclusionRepository _fontInclusionRepository;
        private IFontStyleRepository _fontStyleRepository;
        private IIconRepository _iconRepository;
        private IIconCategoryRepository _iconCategoryRepository;
        private ICompanyRepository _companyRepository;
        private IImageRepository _imageRepository;
        private ISubscriptionRepository _subscriptionRepository;
        private ISubscriptionPlanRepository _subscriptionPlanRepository;
        private ILog4NetLogRepository _log4NetLogRepository;
        private IBlogEntryRepository _blogEntryRepository;

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

        public IFontInclusionRepository FontInclusionRepository
        {
            get { return _fontInclusionRepository ?? (_fontInclusionRepository = new FontInclusionRepository(_context)); }
        }

        public IFontStyleRepository FontStyleRepository
        {
            get { return _fontStyleRepository ?? (_fontStyleRepository = new FontStyleRepository(_context)); }
        }

        public IIconRepository IconRepository
        {
            get { return _iconRepository ?? (_iconRepository = new IconRepository(_context)); }
        }

        public IIconCategoryRepository IconCategoryRepository
        {
            get { return _iconCategoryRepository ?? (_iconCategoryRepository = new IconCategoryRepository(_context)); }
        }

        public ICompanyRepository CompanyRepository
        {
            get { return _companyRepository ?? (_companyRepository = new CompanyRepository(_context)); }
        }
        public IImageRepository ImageRepository
        {
            get { return _imageRepository ?? (_imageRepository = new ImageRepository(_context)); }
        }

        public ISubscriptionRepository SubscriptionRepository
        {
            get { return _subscriptionRepository ?? (_subscriptionRepository = new SubscriptionRepository(_context)); }
        }
        public ISubscriptionPlanRepository SubscriptionPlanRepository
        {
            get { return _subscriptionPlanRepository ?? (_subscriptionPlanRepository = new SubscriptionPlanRepository(_context)); }
        }

        public ILog4NetLogRepository Log4NetLogRepository
        {
            get { return _log4NetLogRepository ?? (_log4NetLogRepository = new Log4NetLogRepository(_context)); }
        }

        public IBlogEntryRepository BlogEntryRepository
        {
            get { return _blogEntryRepository ?? (_blogEntryRepository = new BlogEntryRepository(_context)); }
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
            _fontInclusionRepository = null;
            _fontStyleRepository = null;
            _iconRepository = null;
            _iconCategoryRepository = null;
            _companyRepository = null;
            _imageRepository = null;
            _subscriptionRepository = null;
            _subscriptionPlanRepository = null;
            _log4NetLogRepository = null;
            _blogEntryRepository = null;

            _context.Dispose();
        }

        #endregion

    }
}
