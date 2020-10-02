using System.Collections.Generic;

namespace BrandCi.Core.Domain.User
{
    public class RolePermission : BaseEntity
    {

        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserRole> UserRoles { get; set; }

    }
}