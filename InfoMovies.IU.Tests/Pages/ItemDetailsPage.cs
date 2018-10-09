using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace InfoMovies.IU.Tests.Pages
{
    public class ItemDetailsPage : BasePage
    {
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("ItemDetailsPage"),
            iOS = x => x.Marked("ItemDetailsPage")
        };

        public ItemDetailsPage()
        {
        }

        public void Return()
        {
            App.Back();
        }
    }
}