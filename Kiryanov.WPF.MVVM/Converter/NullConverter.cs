using System;
using System.Globalization;
using Kiryanov.WPF.MVVM.Core.Converter;

namespace Kiryanov.WPF.MVVM.Converter
{
    public sealed class NullConverter : ConverterBase<NullConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is null;
            //return value is null ? "True" : "False";
            //return (value is null).ToString();
        }
    }
}
