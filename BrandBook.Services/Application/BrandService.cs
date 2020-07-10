using BrandBook.Core;
using BrandBook.Core.Services.Application;
using BrandBook.Infrastructure;

namespace BrandBook.Services.Application
{
    public class BrandService : IBrandService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        #region Constructor
        public BrandService()
        {
            _unitOfWork = new UnitOfWork();
        }
        #endregion


        #region Public Methods
        #endregion


        #region Private Methods
        #endregion
    }
}
