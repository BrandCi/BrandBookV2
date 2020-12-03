using BrandCi.Core.Repositories.Brand;
using BrandCi.Core.Repositories.Brand.Font;
using BrandCi.Core.Repositories.Company;
using BrandCi.Core.Repositories.Frontend;
using BrandCi.Core.Repositories.Resource;
using BrandCi.Core.Repositories.Setting;
using BrandCi.Core.Repositories.System;
using BrandCi.Core.Repositories.User;
using System;

namespace BrandCi.Core
{
    public interface IUnitOfWork : IDisposable
    {

        #region Fileds

        IApplicationUserRepository AppUserRepository { get; }
        ISettingRepository SettingRepository { get; }
        IBrandRepository BrandRepository { get; }
        IColorRepository ColorRepository { get; }
        IColorCategoryRepository ColorCategoryRepository { get; }
        IFontInclusionRepository FontInclusionRepository { get; }
        IFontStyleRepository FontStyleRepository { get; }
        IFontRepository FontRepository { get; }
        IIconRepository IconRepository { get; }
        IIconCategoryRepository IconCategoryRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IImageRepository ImageRepository { get; }
        ISubscriptionRepository SubscriptionRepository { get; }
        ISubscriptionPlanRepository SubscriptionPlanRepository { get; }
        ILog4NetLogRepository Log4NetLogRepository { get; }
        INotificationRepository NotificationRepository { get; }
        IBlogEntryRepository BlogEntryRepository { get; }

        #endregion



        #region Methods

        void SaveChanges();
        void SaveChangesAsync();

        new void Dispose();

        #endregion
    }
}
