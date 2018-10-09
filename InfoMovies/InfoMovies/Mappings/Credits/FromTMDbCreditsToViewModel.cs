using InfoMovies.Extensions;
using InfoMovies.Helpers;
using InfoMovies.Models;
using InfoMovies.ViewModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace InfoMovies.Mappings.Credits
{
    public class FromTMDbCreditsToViewModel : Mapping<TMDbCredits, CreditsViewModel>
    {
        protected override Expression<Func<TMDbCredits, CreditsViewModel>> BuildProjection()
        {
            return credits => new CreditsViewModel
            {
                CastCollection = new ObservableRangeCollection<CastViewModel>(credits.Cast.Select(cast =>
                        CreditsMappings.FromTMDbCastToViewModel.ProjectNullable(cast))),
                CrewCollection = new ObservableRangeCollection<CrewViewModel>(credits.Crew.Select(crew =>
                        CreditsMappings.FromTMDbCrewToViewModel.ProjectNullable(crew)))
            };
        }
    }
}