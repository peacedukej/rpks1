using System;
using System.Globalization;
using System.Windows;
using Kiryanov.WPF.MVVM.Core.Converter;

namespace Kiryanov.WPF.MVVM.Converter
{
    public class LogicConverter : MultiConverterBase<LogicConverter>
    {
        public enum Operators
        {
            And,
            Or,
            Not
        }

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(values), "The number of values must be 2");
            }
            
            if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
            {
                return DependencyProperty.UnsetValue;
            }
            
            if (!(Enum.IsDefined(typeof(Operators), parameter)))
            {
                throw new ArgumentException("The operation must be of Logic operators type", nameof(parameter));
            }

            var leftParameter  = (dynamic)values[0];
            var rightParameter  = (dynamic)values[1];
            
            switch ((Operators)parameter)
            {
                case Operators.Or:
                    return (leftParameter || rightParameter).ToString();
                case Operators.And:
                    return (leftParameter && rightParameter).ToString();
                default:
                    throw new ArgumentException("Invalid operation", nameof(parameter));
            }
        }
    }
}
