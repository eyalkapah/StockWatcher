using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using StockWatcher.Models.Models.Models;

namespace StockWatcher.Models.Messages
{
    public class StatusBarMessage : ValueChangedMessage<StatusBarMessageInput>
    {
        public StatusBarMessage(StatusBarMessageInput value) : base(value)
        {
        }
    }
}
