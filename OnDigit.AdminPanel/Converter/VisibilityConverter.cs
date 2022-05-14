using OnDigit.Core.Models.OrderModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OnDigit.AdminPanel.Converter
{
    [ValueConversion(typeof(OrderStatus), typeof(Visibility))]
    public class EnumToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (OrderStatus)value == OrderStatus.Blocked ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
