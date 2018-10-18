using InfoMovies.Interfaces;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfoMovies.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        #region Constants

        private const string RESOURCE_ID = "InfoMovies.Resources.Languages.AppResources";

        #endregion

        #region Statics

        private readonly CultureInfo _cultureInfo = null;

        private static readonly Lazy<ResourceManager> _resourceManager = new Lazy<ResourceManager>(() =>
            new ResourceManager(RESOURCE_ID, IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));

        #endregion

        #region Properties

        public string Text { get; set; }

        #endregion

        #region Constructors

        public TranslateExtension()
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                _cultureInfo = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        #endregion

        #region Public Methods

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Text))
                return string.Empty;

            var translation = _resourceManager.Value.GetString(Text, _cultureInfo);
            if (translation == null)
            {
                if(Debugger.IsAttached)
                    throw new ArgumentException(
                        $"Key '{Text}' was not found in resources '{RESOURCE_ID}' for culture '{_cultureInfo.Name}'.",
                        nameof(Text));
                else
                    translation = Text;
            }

            return translation;
        }

        #endregion
    }
}