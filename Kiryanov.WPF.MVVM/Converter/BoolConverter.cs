using System;
using System.Globalization;
using System.Windows;
using Kiryanov.WPF.MVVM.Core.Converter;

namespace Kiryanov.WPF.MVVM.Converter
{
    public class BoolConverter : ConverterBase<BoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!(value is bool param))
            {
                throw new ArgumentException("Invalid input, op is not bool", nameof(param));
            }
            
            if (value == DependencyProperty.UnsetValue)
            {
                return DependencyProperty.UnsetValue;
            }

            return param ? "True" : "False";
        }
    }
}
