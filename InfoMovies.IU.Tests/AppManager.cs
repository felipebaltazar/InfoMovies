using System;
using Xamarin.UITest;
using Xamarin.UITest.Utils;

namespace InfoMovies.IU.Tests
{
    static class AppManager
    {
        static IApp app;

        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException(
                        "'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return app;
            }
        }

        static Platform? platform;

        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {
            if (Platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    .WaitTimes(new WaitTimes())
                    // Used to run a .apk file:
                    .ApkFile("../../../InfoMovies/InfoMovies.Android/bin/Release/com.companyname.InfoMovies.apk")
                    .StartApp();
            }

            if (Platform == Platform.iOS)
            {
                app = ConfigureApp
                    .iOS
                    .WaitTimes(new WaitTimes())
                    // Used to run a .app file on an ios simulator:
                    //.AppBundle("path/to/file.app")
                    // Used to run a .ipa file on a physical ios device:
                    .InstalledApp("com.companyname.InfoMovies-df")
                    .StartApp();
            }
        }
    }

    public class WaitTimes : IWaitTimes
    {
        public TimeSpan GestureCompletionTimeout => TimeSpan.FromMinutes(1);

        public TimeSpan GestureWaitTimeout => TimeSpan.FromMinutes(1);

        public TimeSpan WaitForTimeout => TimeSpan.FromMinutes(1);
    }
}