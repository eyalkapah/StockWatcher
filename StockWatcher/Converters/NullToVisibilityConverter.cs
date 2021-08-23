using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StockWatcher.Converters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public bool Inverse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Inverse)
                return value != null
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            
            return value == null
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}