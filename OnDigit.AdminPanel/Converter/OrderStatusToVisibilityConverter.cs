using OnDigit.Core.Models.OrderModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OnDigit.AdminPanel.Converter
{
    [ValueConversion(typeof(OrderStatus), typeof(Visibility))]
    public class OrderStatusToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((OrderStatus)value == OrderStatus.Blocked)
                return Visibility.Collapsed;


            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
