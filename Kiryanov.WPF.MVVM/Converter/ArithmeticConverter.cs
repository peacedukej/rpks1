using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows;
using Microsoft.VisualBasic.CompilerServices;
using Kiryanov.WPF.MVVM.Core.Converter;

namespace Kiryanov.WPF.MVVM.Converter
{
    public sealed class ArithmeticConverter : MultiConverterBase<ArithmeticConverter>
    {
        public enum Operators
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            DivisionRemainder
        }

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
            {
                return DependencyProperty.UnsetValue;
            }

            if (values.Length != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(values), "The number of values must be 2");
            }

            if (!(Enum.IsDefined(typeof(Operators), parameter)))
            {
                throw new ArgumentException("The operation must be of Arithmetic operators type", nameof(parameter));
            }

            var leftParameter  = (dynamic)values[0];
            var rightParameter  = (dynamic)values[1];

            switch ((Operators)parameter)
            {
                case Operators.Addition:
                    return leftParameter + rightParameter;
                case Operators.Subtraction:
                    return leftParameter - rightParameter;
                case Operators.Multiplication:
                    return leftParameter * rightParameter;
                case Operators.Division:
                    return leftParameter / rightParameter;
                case Operators.DivisionRemainder:
                    return leftParameter % rightParameter;
                default: 
                    throw new ArgumentException("Invalid operation", nameof(parameter));
            }
        }
    }
}

// using System;
// using System.Globalization;
// using System.Windows;
// using Microsoft.VisualBasic.CompilerServices;
// using Kiryanov.WPF.MVVM.Core.Converter;
//
// namespace Kiryanov.WPF.MVVM.Converter
// {
//     public sealed class ArithmeticConverter : MultiConverterBase<ArithmeticConverter>
//     {
//         public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
//         {
//             if (values.Length != 2)
//             {
//                 throw new ArgumentException("The number of values must be 2", nameof(values));
//             }
//             
//             if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
//             {
//                 return DependencyProperty.UnsetValue;
//             }
//             
//             if (!(parameter is string operation))
//             {
//                 throw new ArgumentException("The operation must be of string type", nameof(parameter));
//             }
//
//             var leftParameter  = (dynamic)values[0];
//             var rightParameter  = (dynamic)values[1];
//
//             switch (operation)
//             {
//                 case "+":
//                     return (leftParameter + rightParameter).ToString();
//                 case "-":
//                     return (leftParameter - rightParameter).ToString();
//                 case "*":
//                     return (leftParameter * rightParameter).ToString();
//                 case "/":
//                     return (leftParameter / rightParameter).ToString();
//                 case "%":
//                     return (leftParameter % rightParameter).ToString();
//                 default: 
//                     throw new ArgumentException("Invalid operation", nameof(operation));
//             }
//         }
//     }
// }

