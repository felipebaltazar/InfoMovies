using InfoMovies.Helpers;
using InfoMovies.Providers;
using System;
using System.Threading.Tasks;

namespace InfoMovies.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        #region Fields

        private int id = 0;
        private string name = string.Empty;
        private string genre = string.Empty;
        private string image = string.Empty;
        private string poster = string.Empty;
        private string overview = string.Empty;
        private CreditsViewModel credits;
        private DateTime releaseDate = DateTime.MinValue;

        #endregion

        #region Properties

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Genre
        {
            get => genre;
            set => SetProperty(ref genre, value);
        }

        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public string Poster
        {
            get => poster;
            set => SetProperty(ref poster, value);
        }

        public string Overview
        {
            get => overview;
            set => SetProperty(ref overview, value);
        }

        public DateTime ReleaseDate
        {
            get => releaseDate;
            set => SetProperty(ref releaseDate, value);
        }

        public CreditsViewModel Credits
        {
            get => credits;
            set => SetProperty(ref credits, value);
        }

        #endregion

        public async Task GetDetailsAsync()
        {
            IsBusy = true;
            using (var provider = new TMDbProvider())
                Credits = await provider.GetCreditsAsync(Id);

            IsBusy = false;
        }
    }
}