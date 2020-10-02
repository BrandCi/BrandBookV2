namespace BrandCi.Core.ViewModels.App.System.LoggingMessages
{
    public class SingleLoggingMessageViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
