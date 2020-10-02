namespace BrandBook.Core.ViewModels.Notification.TemplateType
{
    // ReSharper disable once InconsistentNaming
    public class General_PrivacyRequest
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string RequestType { get; set; }
        public string Message { get; set; }
        public string RequestDate { get; set; }
        public string RequestIp { get; set; }
    }
}
