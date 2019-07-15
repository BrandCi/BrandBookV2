using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Brand
{
    public class BrandPublicSetting : BaseEntity
    {

        public bool IsPublic { get; set; }
        public string ShareString { get; set; }

    }

}
