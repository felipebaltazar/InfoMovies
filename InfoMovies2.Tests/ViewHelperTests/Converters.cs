using InfoMovies.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace InfoMovies.Tests.ViewHelperTests
{
    [TestClass]
    public class Converters
    {
        [TestMethod]
        public void AspecRatioConverterTest()
        {
            var converter = new AspectRatioConverter();
            converter.Ratio = 2;

            var result = converter.Convert(300, null, null, null);
            Assert.AreEqual(result, 300);

            result = converter.Convert((double)300, null, null, null);
            Assert.AreEqual(result, (double)150);

            var convertBackResult = converter.ConvertBack((double)result, null, null, null);
            Assert.AreEqual(convertBackResult, (double)300);
        }

        [TestMethod]
        public void DateTimeConverterTest()
        {
            var dateString = "10/31/1990";
            var cultureInfo = CultureInfo.InvariantCulture;
            var date = DateTime.Parse(dateString, cultureInfo);
            var converter = new DateTimeConverter();
            var result = converter.Convert(date, null, null, cultureInfo);

            Assert.AreEqual(result, date.ToString(
                cultureInfo.DateTimeFormat.ShortDatePattern, cultureInfo));
        }

        [TestMethod]
        public void InvertBooleanConverterTest()
        {
            var converter = new InvertBooleanConverter();
            var result = converter.Convert(true, null, null, null);
            Assert.AreEqual(result, false);

            var convertBackResult = converter.ConvertBack(result, null, null, null);
            Assert.AreEqual(convertBackResult, true);
        }
    }
}
