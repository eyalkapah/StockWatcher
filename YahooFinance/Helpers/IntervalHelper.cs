using System;
using YahooFinance.Enums;

namespace YahooFinance.Helpers
{
    public static class IntervalHelper
    {
        public static string GetIntervalString(this Interval frequency)
        {
            switch (frequency)
            {
                case Interval.OneDay:
                    return "1d";
                case Interval.FiveDays:
                    return "5d";
                case Interval.OneMonth:
                    return "1m";
                case Interval.ThreeMonths:
                    return "3m";
                case Interval.SixMonths:
                    return "6m";
                case Interval.OneYear:
                    return "1y";
                case Interval.TwoYears:
                    return "2y";
                case Interval.FiveYears:
                    return "5y";
                case Interval.TenYears:
                    return "10y";
                case Interval.YearToDate:
                    return "ytd";
                default:
                    throw new ArgumentOutOfRangeException(nameof(frequency), frequency, null);
            }
        } 
    }
}
