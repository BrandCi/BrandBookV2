using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.User
{
    public class SubscriptionPlan : BaseEntity
    {

        public string Name { get; set; }
        public int ValidityInMonths { get; set; }
        public double Price { get; set; }

    }
}
