using BrandBook.Core.Domain.User;

namespace BrandBook.Core.Domain.Company
{
    public class CompanyMembership : BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public bool IsCompanyManager { get; set; }
    }
}
