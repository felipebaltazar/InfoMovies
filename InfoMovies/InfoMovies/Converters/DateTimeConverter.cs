using InfoMovies.Interfaces;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace InfoMovies.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        #region IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime date)
            {
                var datePattern = culture?.DateTimeFormat?.ShortDatePattern;
                return date.ToString(datePattern, culture);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = DateTime.MinValue;
            var dateTime = DateTime.TryParse(value.ToString(), out result);

            return result;
        }

        #endregion
    }
}