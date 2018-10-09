using InfoMovies.Helpers;
using InfoMovies.Interfaces;
using InfoMovies.Resources.Languages;
using System;
using Xamarin.Forms;

namespace InfoMovies
{
    public static class AppConfig
    {
        private static void InitializeCultureInfo()
        {
            try
            {
                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                {
                    var localize = DependencyService.Get<ILocalize>();
                    var cultureInfo = localize.GetCurrentCultureInfo();

                    AppResources.Culture = cultureInfo;
                    localize.SetLocale(cultureInfo);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }
        }
    }
}
