using System;
using Xamarin.Forms;

/// <summary>
/// charlespetzold empirical font size
/// https://github.com/xamarin/xamarin-forms-book-samples/blob/master/Chapter05/EmpiricalFontSize/EmpiricalFontSize/EmpiricalFontSize/FontCalc.cs
/// </summary>

namespace InfoMovies.Helpers
{
    struct FontCalc
    {
        public FontCalc(Label label, double fontSize, double containerWidth)
            : this()
        {
            // Save the font size.
            FontSize = fontSize;

            // Recalculate the Label height.
            label.FontSize = fontSize;
            var sizeRequest =
                label.Measure(containerWidth, double.PositiveInfinity);

            // Save that height.
            TextHeight = sizeRequest.Request.Height;
        }

        public double FontSize { private set; get; }

        public double TextHeight { private set; get; }
    }
}