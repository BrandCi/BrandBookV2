using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.System.LoggingMessages
{
    public class LoggingMessagesViewModel : IEnumerable<SingleLoggingMessageViewModel>
    {
        public IEnumerable<SingleLoggingMessageViewModel> LoggingMessages { get; set; }

        public IEnumerator<SingleLoggingMessageViewModel> GetEnumerator()
        {
            return LoggingMessages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
