using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockWatcher.Models.Enums;
using StockWatcher.Models.Models.Models;

namespace StockWatcher.Services.Interfaces
{
    public interface IStatusBarService
    {
        (string message, string imageSourceName) GetStatusBarPackage(StatusBarMessageType messageType, string message);
    }
}
