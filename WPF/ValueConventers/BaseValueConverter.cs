//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-11
//  ===============================
//  Namespace        : WPF
//  Class                   : BaseValueConverter.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-11
//  Change History: 
// ==================================

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPF.ValueConventers
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        private static T _Converter = null;


        /// <summary>
        /// Provides the value.
        /// </summary>
        /// <param name="p_serviceProvider">The p service provider.</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider p_serviceProvider)
        {
            if (_Converter == null)
            {
                _Converter = new T();
            }


            return _Converter;
        }

        /// <summary>Converts a value. </summary>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>Converts a value. </summary>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}