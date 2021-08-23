using StockWatcher.Models.Enums;

namespace StockWatcher.Models.Models.Models
{
    public class StatusBarMessageInput
    {
        public string Message { get; set; }
        public StatusBarMessageType StatusBarMessageType { get; set; }
    }
}
