using System;
using System.Globalization;
using System.Windows;

namespace WPF.ValueConventers
{
    class NegatableBooleanToVisiblityConverter : BaseValueConverter<NegatableBooleanToVisiblityConverter>
    {
        public bool Negate { get; set; }
        public Visibility FalseVisibility { get; set; }

        public NegatableBooleanToVisiblityConverter()
        {
            FalseVisibility = Visibility.Collapsed;
        }
        /// <summary>Converts a value. </summary>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bVal;
            bool result = bool.TryParse(value.ToString(), out bVal);
            if (!result) return value;
            if (bVal && !Negate) return Visibility.Visible;
            if (bVal && Negate) return FalseVisibility;
            if (!bVal && Negate) return Visibility.Visible;
            if (!bVal && !Negate) return FalseVisibility;
            else return Visibility.Visible;
        }

        /// <summary>Converts a value. </summary>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
