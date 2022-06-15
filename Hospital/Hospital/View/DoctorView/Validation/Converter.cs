using System;
using System.Globalization;
using System.Windows.Data;

namespace Hospital.View.DoctorView.Validation
{
    public class Converter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[0];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { (string)value, (string)value };
        }
    }
}