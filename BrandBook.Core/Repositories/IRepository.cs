using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrandBook.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();


        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);


        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
