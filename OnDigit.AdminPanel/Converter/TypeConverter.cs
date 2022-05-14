using OnDigit.Core.Models.OrderModel;
using System;
using System.Globalization;
using System.Windows.Data;

namespace OnDigit.AdminPanel.Converter
{
    [ValueConversion(typeof(OrderStatus), typeof(int))]
    public class TypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)(OrderStatus)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (OrderStatus)(int)value;
        }
    }
}
