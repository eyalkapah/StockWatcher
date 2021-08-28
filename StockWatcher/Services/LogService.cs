using Serilog;
using StockWatcher.Services.Interfaces;
using System;

namespace StockWatcher.Services
{
    public class LogService : ILogService
    {
        public LogService()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File("Logs\\App.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void Verbose(Exception exception, string message)
        {
            Log.Verbose(exception, message);
        }

        public void Verbose(string message)
        {
            Log.Verbose(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Information(string message)
        {
            Log.Information(message);
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }
    }
}
