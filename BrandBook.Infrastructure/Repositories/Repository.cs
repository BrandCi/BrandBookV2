using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.RepositoryInterfaces;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private BrandBookDbContext _context;
        private DbSet<TEntity> _set;

        internal Repository(BrandBookDbContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> Set
        {
            get
            {
                return _set ?? (_set = _context.Set<TEntity>());
            }

        }


        public List<TEntity> GetAll()
        {
            return Set.ToList();
        }

    }
}
