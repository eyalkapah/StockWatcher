using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace StockWatcher.Models.Messages
{
    public class RefreshMessage : ValueChangedMessage<object>
    {
        public RefreshMessage(object value) : base(value)
        {
        }
    }
}
