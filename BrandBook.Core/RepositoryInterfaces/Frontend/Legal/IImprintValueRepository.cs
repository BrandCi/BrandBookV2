using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Frontend.Legal;

namespace BrandBook.Core.RepositoryInterfaces.Frontend.Legal
{
    public interface IImprintValueRepository : IDisposable
    {

        IEnumerable<ImprintValue> GetImprintValues();
        ImprintValue GetImprintValue(int imprintValueId);
        IEnumerable<ImprintValue> GetImprintValuesFromCategory(int imprintCategory);

    }
}
