using System;

namespace InfoMovies.Helpers
{
    public sealed class PlatformCulture
    {
        #region Properties

        public string PlatformString { get; private set; }
        public string LanguageCode { get; private set; }
        public string LocaleCode { get; private set; }

        #endregion

        #region Constructors

        public PlatformCulture(string platformCultureString)
        {
            if (string.IsNullOrEmpty(platformCultureString))
                throw new ArgumentException(
                    "Expected culture identifier", "platformCultureString");

            PlatformString = platformCultureString.Replace("_", "-");
            var dashIndex = PlatformString.IndexOf("-", StringComparison.Ordinal);

            if (dashIndex > 0)
            {
                var parts = PlatformString.Split('-');

                LanguageCode = parts[0];
                LocaleCode = parts[1];
            }
            else
            {
                LanguageCode = PlatformString;
                LocaleCode = "";
            }
        }

        #endregion

        #region Overrides

        public override string ToString() => PlatformString;

        #endregion
    }
}