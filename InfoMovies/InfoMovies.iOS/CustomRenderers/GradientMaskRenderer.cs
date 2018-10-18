using CoreAnimation;
using CoreGraphics;
using InfoMovies.Helpers;
using InfoMovies.iOS.CustomRenderers;
using InfoMovies.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientMask), typeof(GradientMaskRenderer))]
namespace InfoMovies.iOS.CustomRenderers
{
    public class GradientMaskRenderer : VisualElementRenderer<GradientMask>
    {
        #region Overrides

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            try
            {
                var topColor = Element.TopColor.ToCGColor();
                var bottomColor = Element.BottomColor.ToCGColor();
                var gradientLayer = new CAGradientLayer
                {
                    Frame = rect,
                    Colors = new CGColor[] { topColor, bottomColor }
                };

                NativeView.Layer.InsertSublayer(gradientLayer, 0);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }
        }

        #endregion
    }
}