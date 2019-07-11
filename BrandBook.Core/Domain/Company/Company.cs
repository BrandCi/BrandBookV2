using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Company
{
    public class Company : BaseEntity
    {

        public string Name { get; set; }
        public string UrlName { get; set; }
        public string ContactEmail { get; set; }


    }
}
