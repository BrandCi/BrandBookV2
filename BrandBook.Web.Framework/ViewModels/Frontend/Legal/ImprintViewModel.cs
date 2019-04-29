using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Frontend.Legal;

namespace BrandBook.Web.Framework.ViewModels.Frontend.Legal
{
    public class ImprintViewModel
    {
        public IEnumerable<ImprintValue> ImprintValues { get; set; }
    }
}
