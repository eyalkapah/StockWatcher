using System;

namespace StockWatcher.Models.Extensions
{
    public static class DateTimeExtensions
    {
        public static decimal ToUnixTimeSeconds(this DateTime dateTime)
        {
            var dto = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute,
                dateTime.Second, TimeSpan.Zero);

            return dto.ToUnixTimeSeconds();
        }

        public static DateTime FromUnixTimeSeconds(long seconds)
        {
            var dto = DateTimeOffset.FromUnixTimeSeconds(seconds);
            return dto.DateTime;
        }

        public static DateTime MakeCandleOf(this DateTime dateTime, int candleNum)
        {
            var noSeconds = DateTime.Parse(dateTime.ToString("g"));

            return noSeconds.AddMinutes(-noSeconds.Minute % candleNum);
        }
    }
}
