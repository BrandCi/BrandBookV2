using System.Collections;
using System.Collections.Generic;

namespace BrandCi.Core.ViewModels.App.System.LoggingMessages
{
    public class LoggingMessagesViewModel : IEnumerable<SingleLoggingMessageViewModel>
    {
        public List<SingleLoggingMessageViewModel> LoggingMessages { get; set; }

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
