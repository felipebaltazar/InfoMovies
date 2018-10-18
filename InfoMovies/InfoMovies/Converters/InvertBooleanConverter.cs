using System;
using System.Globalization;
using Xamarin.Forms;

namespace InfoMovies.Converters
{
    public class InvertBooleanConverter : IValueConverter
    {
        #region IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool boolean)
                return !boolean;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolean)
                return !boolean;

            return value;
        }

        #endregion
    }
}