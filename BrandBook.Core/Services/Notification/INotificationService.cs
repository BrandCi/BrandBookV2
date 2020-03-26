using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Services.Messaging
{
    public interface INotificationService
    {
        bool SendNotification(string receiver, string subject, string content);
    }
}
