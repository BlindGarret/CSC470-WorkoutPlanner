using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

//This is a WPF converter. We will probably be writing a few of these. They act as helper classes during WPF binding.

//For example, this converter is a base converter to be used to change a Boolean value to something more useful.

//See BooleanToVisibilityConverter.

//The reason for this is WPF will do NO IMPLICIT CONVERSION for you. This is safer, and makes you write what you mean.

namespace WorkoutHelper.Converters
{
    public class BooleanConverter<T> : IValueConverter
    {
        public BooleanConverter(T trueValue, T falseValue)
        {
            True = trueValue;
            False = falseValue;
        }

        public T True { get; set; }
        public T False { get; set; }

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool b && b ? True : False;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is T variable && EqualityComparer<T>.Default.Equals(variable, True);
        }
    }
}