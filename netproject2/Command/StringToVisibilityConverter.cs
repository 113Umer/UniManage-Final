using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace netproject2.Commands
{
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = value as string;

            // If the string is null or empty, make the element visible; otherwise, collapse it
            return string.IsNullOrEmpty(input) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
