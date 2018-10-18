using InfoMovies.Mappings.Movie;
using InfoMovies.Models;
using InfoMovies.ViewModels;

namespace InfoMovies.Mappings
{
    public static class MovieMappings
    {
        public static Mapping<TMDbMovie, MovieViewModel> FromTMDMovieToViewModel =
            new FromTMDbMovieToViewModel();
    }
}