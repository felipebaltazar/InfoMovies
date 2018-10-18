using InfoMovies.Models;
using InfoMovies.Providers;
using InfoMovies.ViewModels;
using System;
using System.Linq.Expressions;

namespace InfoMovies.Mappings.Credits
{
    public class FromTMDbCastToViewModel : Mapping<TMDbCast, CastViewModel>
    {
        protected override Expression<Func<TMDbCast, CastViewModel>> BuildProjection()
        {
            return cast => new CastViewModel
            {
                Character = cast.Character,
                Name = cast.Name,
                ProfilePath = string.Concat(TMDbProvider.BASE_IMAGE_URL, cast.ProfilePath)
            };
        }
    }
}