using NUnit.Framework;
using Xamarin.UITest;

namespace InfoMovies.IU.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests : BaseTestFixture
    {
        public Tests(Platform platform)
            : base(platform)
        {
        }

        [Test]
        public void NavigationTest()
        {
            new Pages.MainPage()
                .SelectMovie();

            new Pages.ItemDetailsPage()
                .Return();
        }
    }
}
