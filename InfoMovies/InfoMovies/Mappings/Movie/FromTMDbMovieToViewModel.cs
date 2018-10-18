
using InfoMovies.Models;
using InfoMovies.Providers;
using InfoMovies.ViewModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace InfoMovies.Mappings.Movie
{
    public class FromTMDbMovieToViewModel : Mapping<TMDbMovie, MovieViewModel>
    {
        protected override Expression<Func<TMDbMovie, MovieViewModel>> BuildProjection()
        {
            return movie => new MovieViewModel
            {
                Id = movie.Id,
                Name = movie.Title,
                Genre = FortmatGenre(movie.GenreIds),
                Overview = movie.Overview,
                Image = string.Concat(TMDbProvider.BASE_IMAGE_URL, movie.BackdropPath),
                Poster = string.Concat(TMDbProvider.BASE_IMAGE_URL, movie.PosterPath),
                ReleaseDate = ParseDate(movie.ReleaseDate)
            };
        }

        #region Private Methods

        private DateTime ParseDate(string releaseDate)
        {
            var date = DateTime.MinValue;
            DateTime.TryParse(releaseDate, out date);

            return date;
        }

        private string FortmatGenre(int[] genreIds)
        {
            var genreStrings = genreIds
                .Select(id => TMDbProvider.GenreCollection?.Genres?.FirstOrDefault(g => g.Id == id)?.Name)
                .Where(g => !string.IsNullOrEmpty(g));

            return string.Join(", ", genreStrings);

        }

        #endregion
    }
}