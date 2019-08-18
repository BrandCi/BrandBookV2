using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core;
using BrandBook.Infrastructure;

namespace BrandBook.Services.Subscriptions
{
    public class SubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionService()
        {
            this._unitOfWork = new UnitOfWork();
        }

    }
}
