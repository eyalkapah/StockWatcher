using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace StockWatcher.Models.Messages
{
    public class ShutdownMessage : ValueChangedMessage<bool>
    {
        public ShutdownMessage(bool value) : base(value)
        {
        }
    }
}
