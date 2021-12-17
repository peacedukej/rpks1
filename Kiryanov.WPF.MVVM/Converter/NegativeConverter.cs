using System;
using System.Globalization;
using System.Windows;
using Kiryanov.WPF.MVVM.Converter;
using Kiryanov.WPF.MVVM.Core.Converter;

namespace Kiryanov.WPF.MVVM.Converter
{

    public class NegativeConverter : ConverterBase<LogicConverter>
    {
        public enum Operators
        {
            LogicNot,
            BitwiseNot
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value == DependencyProperty.UnsetValue)
            {
                return DependencyProperty.UnsetValue;
            }

            if (!(Enum.IsDefined(typeof(Operators), parameter)))
            {
                throw new ArgumentException("The operation must be of Negative operators type", nameof(parameter));
            }

            var convertParam = (dynamic) value;

            switch ((Operators) parameter)
            {
                case Operators.BitwiseNot:
                    return (~convertParam).ToString();
                case Operators.LogicNot:
                    return (!convertParam).ToString();
                default:
                    throw new ArgumentException("Invalid operation", nameof(parameter));
            }
        }
    }
}
