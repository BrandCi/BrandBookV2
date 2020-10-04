namespace BrandBook.Core.Domain.System.Notification
{
    public class Notification : BaseEntity
    {
        public NotificationTemplateType NotificationTemplateType { get; set; }
        public string Subject { get; set; }
        public string CreationDate { get; set; }
        public string EmailAddress { get; set; }
        public string RequestIp { get; set; }
        public string EmailContent { get; set; }
        public bool IsSpam { get; set; }
        public bool IsSent { get; set; }
        public string ErrorMessage { get; set; }
    }
}
