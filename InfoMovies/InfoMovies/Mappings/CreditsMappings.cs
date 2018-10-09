using InfoMovies.Mappings.Credits;
using InfoMovies.Models;
using InfoMovies.ViewModels;

namespace InfoMovies.Mappings
{
    public static class CreditsMappings
    {
        public static Mapping<TMDbCredits, CreditsViewModel> FromTMDbCreditsToViewModel =
            new FromTMDbCreditsToViewModel();

        public static Mapping<TMDbCrew, CrewViewModel> FromTMDbCrewToViewModel =
            new FromTMDbCrewToViewModel();

        public static Mapping<TMDbCast, CastViewModel> FromTMDbCastToViewModel =
            new FromTMDbCastToViewModel();
    }
}