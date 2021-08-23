﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StockWatcher.Converters
{
    public class GeneralToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                return string.IsNullOrWhiteSpace(str)
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            }

            if (value is bool b)
            {
                return b
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
