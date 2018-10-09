using System;
using System.Globalization;
using Xamarin.Forms;

namespace InfoMovies.Converters
{
    class MaxCharConverter : IValueConverter
    {
        #region Properties

        public int MaxCharCount { set; get; }

        #endregion

        #region IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
                return StringFormat(text);

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        #endregion

        private string StringFormat(string source)
        {
            var result = string.Empty;
            if (!(source.Length > MaxCharCount))
            {
                result = source;
            }
            else
            {
                var words = source.Split(' ');
                foreach (var word in words)
                {
                    if ((result.Length + word.Length) > 20)
                    {
                        result += "...";
                        break;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(result))
                            result += " ";

                        result += word;
                    }
                }
            }

            return result;
        }
    }
}
