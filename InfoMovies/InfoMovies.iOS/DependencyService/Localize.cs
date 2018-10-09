using Foundation;
using InfoMovies.Helpers;
using InfoMovies.Interfaces;
using InfoMovies.iOS.DependencyService;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace InfoMovies.iOS.DependencyService
{
    public class Localize : ILocalize
    {
        #region ILocalize

        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = IOSToDotnetLanguage(pref);
            }
            CultureInfo ci = null;

            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {
                LogHelper.LogException(e1);
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    ci = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException e2)
                {
                    LogHelper.LogException(e2);
                    ci = new CultureInfo("en");
                }
            }

            return ci;
        }

        #endregion

        #region Private Methods

        private string IOSToDotnetLanguage(string iOSLanguage)
        {
            var netLanguage = iOSLanguage;
            switch (iOSLanguage)
            {
                case "ms-MY":
                case "ms-SG":
                    netLanguage = "ms";
                    break;
                case "gsw-CH":
                    netLanguage = "de-CH";
                    break;
            }

            return netLanguage;
        }

        private string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            var netLanguage = platCulture.LanguageCode;
            switch (platCulture.LanguageCode)
            {
                case "pt":
                    netLanguage = "pt-PT";
                    break;
                case "gsw":
                    netLanguage = "de-CH";
                    break;
            }
            return netLanguage;
        }

        #endregion
    }
}