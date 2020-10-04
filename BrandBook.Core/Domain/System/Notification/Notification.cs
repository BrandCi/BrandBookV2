using System;

namespace BrandBook.Core.Domain.System.Notification
{
    public class Notification : BaseEntity
    {
        public NotificationTemplateType NotificationTemplateType { get; set; }
        public DateTime CreationDate { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set;}
        public string RequestId { get; set; }
        public string EmailContent { get; set; }
    }
}
