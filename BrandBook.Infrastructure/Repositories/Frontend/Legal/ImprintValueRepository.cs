using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Frontend.Legal;
using BrandBook.Core.RepositoryInterfaces.Frontend.Legal;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Frontend.Legal
{
    public class ImprintValueRepository : IImprintValueRepository
    {

        private BrandBookDbContext context;

        public ImprintValueRepository(BrandBookDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<ImprintValue> GetImprintValues()
        {
            return context.ImprintValues.ToList();
        }

        public ImprintValue GetImprintValue(int imprintValueId)
        {
            return context.ImprintValues.Find(imprintValueId);
        }

        public IEnumerable<ImprintValue> GetImprintValuesFromCategory(ImprintCategory imprintCategory)
        {
            return context.ImprintValues.Where(i => i.Category == imprintCategory).ToList();
        }




        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
