using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using Kiryanov.WPF.MVVM.Core.Converter;

namespace Kiryanov.WPF.MVVM.Converter
{
    public class BitwiseConverter : MultiConverterBase<BitwiseConverter>
    {
        public enum Operators
        {
            Xor,
            Or,
            And
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
                throw new ArgumentException("The operation must be of Bitwise operators type", nameof(parameter));
            } 
            
            var leftParameter = System.Convert.ToInt32(values[0]);
            var rightParameter  = System.Convert.ToInt32(values[1]);
            
            switch ((Operators)parameter)
            {
                case Operators.Xor:
                    return (leftParameter ^ rightParameter).ToString();
                case Operators.And:
                    return (leftParameter & rightParameter).ToString();
                case Operators.Or:
                    return (leftParameter | rightParameter).ToString();
                default:
                    throw new ArgumentException("Invalid operation", nameof(parameter));
            }
        }
    }
}
