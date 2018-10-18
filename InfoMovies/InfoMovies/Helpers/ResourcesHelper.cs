using InfoMovies.Interfaces;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace InfoMovies.Helpers
{
    public static class ResourcesHelper
    {
        #region Constants

        public const string RESOURCE_PREFIX = "InfoMovies.Resources";

        #endregion

        #region ReadOnly

        private static readonly Assembly _assembly = typeof(App).GetTypeInfo().Assembly;
        private static readonly ILocalize _localize = DependencyService.Get<ILocalize>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Get iamge resource route with current culture
        /// </summary>
        /// <param name="Name">resource name</param>
        /// <returns></returns>
        public static string GetImageRouteCurrentCulture(string Name)
        {
            var currentCulture = _localize?.GetCurrentCultureInfo();
            if (currentCulture != null && !currentCulture.Name.Equals("en"))
            {
                var nameWithouExt = Path.GetFileNameWithoutExtension(Name);
                var extension = Path.GetExtension(Name);
                var fullRoute = string.Join(
                ".", RESOURCE_PREFIX, "Images", nameWithouExt, string.Concat(currentCulture.Name, extension));

                return fullRoute;
            }

            return Name;
        }

        #endregion
    }
}