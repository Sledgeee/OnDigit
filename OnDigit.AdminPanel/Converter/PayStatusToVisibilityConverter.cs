using OnDigit.Core.Models.OrderModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OnDigit.AdminPanel.Converter
{
    [ValueConversion(typeof(PayStatus), typeof(Visibility))]
    public class PayStatusToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((PayStatus)value == PayStatus.Paid)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}