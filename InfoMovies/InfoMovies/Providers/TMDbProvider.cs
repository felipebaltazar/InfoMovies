using InfoMovies.Extensions;
using InfoMovies.Helpers;
using InfoMovies.Interfaces;
using InfoMovies.Mappings;
using InfoMovies.Models;
using InfoMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InfoMovies.Providers
{
    public sealed class TMDbProvider : IDisposable
    {
        #region Constants

        private const string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        public const string BASE_IMAGE_URL = "https://image.tmdb.org/t/p/w400/";

        #endregion

        #region Read Only

        private static WebApiClient client;
        private static ILocalize localize;

        #endregion

        #region Fields

        private TMDbPage currentPage;
        private TMDbPage currentSearchPage;
        private static TMDbGenreCollection genreCollection;

        #endregion

        #region Properties

        public static TMDbGenreCollection GenreCollection
        {
            get
            {
                if (genreCollection == null)
                    InitialilizeDefaults();

                return genreCollection;
            }
            set
            {
                genreCollection = value;
            }
        }

        #endregion

        #region Constructors

        public TMDbProvider()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.themoviedb.org/3/"),
                Timeout = new TimeSpan(0, 0, 30)
            };

            client = new WebApiClient(httpClient);
            localize = DependencyService.Get<ILocalize>();

            InitialilizeDefaults();
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<TMDbMovie>> GetUpcommingMoviesAsync(int page = 1)
        {
            if(currentPage == null || currentPage.TotalPages >= page)
            {
                var currentCulture = localize.GetCurrentCultureInfo();
                var language = currentCulture.Name;
                currentPage = await client.GetAsync<TMDbPage>(
                    $"movie/upcoming?api_key={API_KEY}&page={page}&language={language}");
                return currentPage?.Results.Distinct();
            }

            return null;
        }

        public async Task<IEnumerable<TMDbMovie>> SearchAsync(string searchText, int page = 1)
        {
            if (currentSearchPage == null || currentSearchPage.TotalPages >= page)
            {
                var searchQuery = searchText.Replace(" ", "+");
                searchQuery = System.Web.HttpUtility.UrlEncode(searchQuery);

                var currentCulture = localize.GetCurrentCultureInfo();
                var language = currentCulture.Name;
                var url = $"search/movie?api_key={API_KEY}&query={searchQuery}&page={page}&language={language}";

                currentSearchPage = await client.GetAsync<TMDbPage>(url);

                LogHelper.TrackEvent(nameof(SearchAsync), new Dictionary<string, string>()
                {
                    {"Total Results", currentSearchPage?.Results?.Length.ToString() },
                    {"Search text", searchText}
                });

                return currentSearchPage?.Results.Distinct();
            }

            return null;
        }

        public async Task<CreditsViewModel> GetCreditsAsync(int id)
        {
            if (id > 0)
            {
                var currentCulture = localize.GetCurrentCultureInfo();
                var language = currentCulture.Name;
                var url = $"movie/{id}/credits?api_key={API_KEY}&language={language}";

                var credits = await client.GetAsync<TMDbCredits>(url);
                return CreditsMappings.FromTMDbCreditsToViewModel.ProjectNullable(credits);
            }

            return null;
        }

        private static async void InitialilizeDefaults()
        {
            await InitializeGenreList();
        }

        public static async Task InitializeGenreList()
        {
            var currentCulture = localize.GetCurrentCultureInfo();
            var language = currentCulture.Name;
            GenreCollection = await client.GetAsync<TMDbGenreCollection>($"genre/movie/list?api_key={API_KEY}&language={language}");
        }

        #endregion

        #region IDisposable

        public void Dispose() =>
            client.Dispose();

        #endregion
    }
}