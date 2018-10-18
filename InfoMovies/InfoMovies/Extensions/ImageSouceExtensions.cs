using InfoMovies.Helpers;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfoMovies.Extensions
{
    public class ImageSourceExtensions : IMarkupExtension
    {
        #region Properties

        public string Source { get; set; }

        #endregion

        #region IMarkupExtension

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Source))
                return null;

            var sourceCurrentCulture = ResourcesHelper.GetImageRouteCurrentCulture(Source);
            var imageSource = ImageSource.FromResource(sourceCurrentCulture);

            var assembly = Assembly.GetExecutingAssembly();
            assembly.GetManifestResourceStream(sourceCurrentCulture);

            return imageSource;
        }

        #endregion
    }
}