using System;
using System.Globalization;
using Xamarin.Forms;

namespace InfoMovies.Converters
{
    public class AspectRatioConverter : IValueConverter
    {
        #region Properties

        public float Ratio { set; get; }

        #endregion

        #region IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is double width)
            {
                if (width > 0)
                    return width / Ratio;
                else
                    return 1;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double height)
            {
                if(height > 0)
                    return height * Ratio;
                else
                    return 1;
            }

            return value;
        }

        #endregion
    }
}
