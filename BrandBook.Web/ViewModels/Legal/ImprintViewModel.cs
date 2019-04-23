using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrandBook.Core.Domain.Frontend.Legal;

namespace BrandBook.Web.ViewModels.Legal
{
    public class ImprintViewModel
    {
        public IEnumerable<ImprintValue> ImprintValues { get; set; }
    }
}