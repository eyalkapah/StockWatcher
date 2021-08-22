using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace StockWatcher.Converters
{
    public class TrendColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (double.TryParse(value.ToString(), out var num))
            {
                if (num > 0)
                    return Application.Current.Resources["UpGreenBrush"] as SolidColorBrush;
                if (num < 0)
                    return Application.Current.Resources["DownRedBrush"] as SolidColorBrush;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
