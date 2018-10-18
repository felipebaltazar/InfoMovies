using System.Threading.Tasks;
using Xamarin.Forms;

namespace InfoMovies.Helpers
{
    public static class NavigationHelper
    {
        #region Public Singletons

        public static Page CurrentPage => Application.Current.MainPage;
        public static INavigation Navigation => CurrentPage.Navigation;

        #endregion

        #region Public Methods

        /// <summary>
        /// Pop current presented page
        /// </summary>
        /// <returns></returns>
        public static async Task PopAsync()
        {
            if (CurrentPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false;
                await masterDetailPage.Detail.Navigation.PopAsync(true);
            }
            else
            {
                if (CurrentPage is NavigationPage navigationPage)
                    if (navigationPage.RootPage is MasterDetailPage navMasterDetailPage)
                        navMasterDetailPage.IsPresented = false;

                await Navigation.PopAsync(true);
            }
        }

        /// <summary>
        /// Push a page on current navigation
        /// </summary>
        /// <param name="page">Page to show</param>
        /// <returns></returns>
        public static async Task PushAsync(Page page)
        {
            if (CurrentPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false;
                await masterDetailPage.Detail.Navigation.PushAsync(page);
            }
            else
            {
                if (CurrentPage is NavigationPage navigationPage)
                    if (navigationPage.RootPage is MasterDetailPage navMasterDetailPage)
                        navMasterDetailPage.IsPresented = false;

                await Navigation.PushAsync(page);
            }
        }

        /// <summary>
        /// Pop to root page
        /// </summary>
        /// <returns></returns>
        public static async Task PopToRootAsync() =>
            await Navigation.PopToRootAsync(true);

        #endregion
    }
}