﻿namespace StockWatcher.Models.Settings
{
    public class ApplicationSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public string DataProvider { get; set; }
    }

    public class ConnectionStrings
    {
        public string StockWatcher { get; set; }
    }

}

