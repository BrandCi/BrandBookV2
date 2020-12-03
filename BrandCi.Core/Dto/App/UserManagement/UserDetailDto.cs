namespace BrandCi.Core.Dto.App.UserManagement
{
    public class UserDetailDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public int IsActive { get; set; }

        public string CreationDate { get; set; }
        public string LastLoginDate { get; set; }
        public string LastModifiedDate { get; set; }

        public int IsEmailConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
        public int LockoutEnabled { get; set; }
        public int PrivacyPolicyAccepted { get; set; }
        public int IsDarkmodeEnabled { get; set; }

        public string ProfileImagePath { get; set; }
    }
}