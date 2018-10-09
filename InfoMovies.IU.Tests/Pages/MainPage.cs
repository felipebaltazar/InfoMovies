using InfoMovies.Views;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace InfoMovies.IU.Tests.Pages
{
    public class MainPage : BasePage
    {
        readonly Query topButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("MainPage"),
            iOS = x => x.Marked("MainPage")
        };

        public MainPage()
        {
            topButton = x => x.Class("TopButtom");
        }

        public void SelectMovie()
        {
            App.Tap(x => x.Marked("ItemMovie"));
        }

        public void GoToTop()
        {
            App.Tap(topButton);
        }
    }
}