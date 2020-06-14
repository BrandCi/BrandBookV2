using BrandBook.Core.Domain.User;
using BrandBook.Core.Repositories.User;
using BrandBook.Infrastructure.Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace BrandBook.Infrastructure.Repositories.User
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly BrandBookDbContext _brandBookDbContext;
        public AppUserRepository(BrandBookDbContext context)
            : base(context)
        {
            _brandBookDbContext = context;
        }


        public AppUser FindByUsername(string userName)
        {
            return Set.FirstOrDefault(x => x.UserName == userName);
        }


        public void UpdateWithModification(AppUser user)
        {
            user.LastModified = DateTime.Now;
            _brandBookDbContext.Entry(user).State = EntityState.Modified;
        }

    }
}