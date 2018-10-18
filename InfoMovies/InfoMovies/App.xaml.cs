
using InfoMovies.Helpers;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InfoMovies
{
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=7bb8f273-7216-4aed-82f7-7e42e2253e50;" +
                  "ios=951f6f78-67b9-41c4-93c3-ec316586c8b7",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {}

        protected override void OnResume()
        {}

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if(e?.ExceptionObject is Exception exception)
                LogHelper.LogException(exception);

            if (Debugger.IsAttached)
                Debugger.Break();
        }
    }
}