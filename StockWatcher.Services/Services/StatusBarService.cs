using StockWatcher.Models.Enums;
using StockWatcher.Services.Interfaces;
using System;

namespace StockWatcher.Services.Services
{
    public class StatusBarService : IStatusBarService
    {
        public (string message, string imageSourceName) GetStatusBarPackage(StatusBarMessageType messageType, string message)
        {
            switch (messageType)
            {
                case StatusBarMessageType.Sync:
                    return (message, "SyncImage");
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
            }
        }
    }
}
