using BrandCi.Core;
using BrandCi.Core.Repositories.Brand;
using BrandCi.Core.Repositories.Brand.Font;
using BrandCi.Core.Repositories.Company;
using BrandCi.Core.Repositories.Frontend;
using BrandCi.Core.Repositories.Resource;
using BrandCi.Core.Repositories.Setting;
using BrandCi.Core.Repositories.System;
using BrandCi.Core.Repositories.User;
using BrandCi.Infrastructure.Data;
using BrandCi.Infrastructure.Repositories.Brand;
using BrandCi.Infrastructure.Repositories.Brand.Font;
using BrandCi.Infrastructure.Repositories.Company;
using BrandCi.Infrastructure.Repositories.Frontend;
using BrandCi.Infrastructure.Repositories.Resource;
using BrandCi.Infrastructure.Repositories.Setting;
using BrandCi.Infrastructure.Repositories.System;
using BrandCi.Infrastructure.Repositories.User;

namespace BrandCi.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fileds

        private readonly ApplicationDbContext _context;

        private IApplicationUserRepository _applicationUserRepository;
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
        private INotificationRepository _notificationRepository;
        private IBlogEntryRepository _blogEntryRepository;

        #endregion

        #region Constructor

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Member from IUnitOfWork

        public IApplicationUserRepository ApplicationUserRepository
        {
            get { return _applicationUserRepository ?? (_applicationUserRepository = new ApplicationUserRepository(_context)); }
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

        public INotificationRepository NotificationRepository
        {
            get { return _notificationRepository ?? (_notificationRepository = new NotificationRepository(_context)); }
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
            _applicationUserRepository = null;
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
            _notificationRepository = null;
            _blogEntryRepository = null;

            _context.Dispose();
        }

        #endregion

    }
}
