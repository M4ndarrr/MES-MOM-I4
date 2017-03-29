//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-11
//  ===============================
//  Namespace        : WPF
//  Class                   : ApplicationPageValueConverter.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-11
//  Change History: 
// ==================================


using System;
using System.Globalization;
using WPF.Model;
using WPF.View;
using LoginControl = WPF.Modules.SystemModule.Login.LoginControl;

namespace WPF.ValueConventers
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">value - null</exception>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((ApplicationPage)value)
            {
                case ApplicationPage.LoginControl:
                    return new LoginControl();
                case ApplicationPage.ProfileUser:
                    return null;
                case ApplicationPage.DashBoard:
                    return null;
                  
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
            return null;
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
