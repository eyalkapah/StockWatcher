using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockWatcher.Models;
using StockWatcher.Models.Settings;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.Services.Services
{
    public class SettingsService : ISettingsService
    {
        public ApplicationSettings Settings { get; }

        public SettingsService(ApplicationSettings settings)
        {
            Settings = settings;
        }
    }
}
