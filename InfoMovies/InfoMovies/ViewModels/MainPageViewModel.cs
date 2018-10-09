using InfoMovies.Extensions;
using InfoMovies.Helpers;
using InfoMovies.Mappings;
using InfoMovies.Models;
using InfoMovies.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InfoMovies.ViewModels
{
    public sealed class MainPageViewModel : BaseViewModel
    {
        #region ReadOnly

        private readonly TMDbProvider _provider =
            new TMDbProvider();

        #endregion

        #region Fields

        private string searchText = string.Empty;
        private bool isRefreshing = false;
        private bool isSearching = false;
        private int currentPage = 1;
        private ObservableRangeCollection<MovieViewModel> movies;

        #endregion

        #region Properties

        public ObservableRangeCollection<MovieViewModel> Movies
        {
            get => movies;
            set => SetProperty(ref movies, value);
        }

        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }

        public bool IsSearching
        {
            get => isSearching;
            set => SetProperty(ref isSearching, value);
        }

        public string SearchText
        {
            get => searchText;
            set => SetProperty(ref searchText, value, onChanged:OnSerachTextUpdate);
        }

        public ICommand SearchCommand { get; private set; }

        public ICommand RefreshCommand { get; private set; }

        #endregion

        #region Constructors

        public MainPageViewModel()
        {
            Movies = new ObservableRangeCollection<MovieViewModel>();

            SearchCommand = new Command<string>(async (textParameter) =>
                await SearchCommandExecute(textParameter));

            RefreshCommand = new Command(async () =>
            {
                IsRefreshing = false;
                if (IsBusy)
                    return;

                currentPage = 1;
                movies.Clear();

                await LoadItemsAsync();
            });
        }
        #endregion

        #region Public Methods

        public async Task LoadItemsAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            isSearching = false;
            SearchText = string.Empty;

            var tmdbMovies = await _provider.GetUpcommingMoviesAsync(currentPage);
            if (!(tmdbMovies?.Count() > 0))
            {
                IsBusy = false;
                return;
            }
            currentPage++;
            FillMoviesCollection(tmdbMovies);
            IsBusy = false;
        }

        public async Task LoadSearchItemsAsync()
        {
            await SearchCommandExecute(SearchText);
        }

        #endregion

        private async Task SearchCommandExecute(string searchText)
        {
            IsBusy = true;

            if (string.IsNullOrEmpty(searchText))
            {
                if(isSearching)
                {
                    movies.Clear();
                    await LoadItemsAsync();
                }   
            }
            else
            {
                if (!isSearching)
                {
                    currentPage = 1;
                    movies.Clear();
                }

                isSearching = true;

                var tmdbMovies =  await _provider.SearchAsync(searchText, currentPage);
                FillMoviesCollection(tmdbMovies);
                currentPage++;
            }

            IsBusy = false;
        }

        private void FillMoviesCollection(IEnumerable<TMDbMovie> collectionToAdd)
        {
            var listToAdd = collectionToAdd
                   .Select(m => MovieMappings.FromTMDMovieToViewModel.ProjectNullable(m))
                   .Where(m => m != null)
                   .OrderBy(m => m.ReleaseDate);

            Movies.AddRange(listToAdd);
        }

        private void OnSerachTextUpdate()
        {
            isSearching = false;
        }
    }
}