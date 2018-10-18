using InfoMovies.Models;
using InfoMovies.ViewModels;
using System;
using System.Linq.Expressions;

namespace InfoMovies.Mappings.Credits
{
    public class FromTMDbCrewToViewModel : Mapping<TMDbCrew, CrewViewModel>
    {
        protected override Expression<Func<TMDbCrew, CrewViewModel>> BuildProjection()
        {
            return crew => new CrewViewModel
            {
                Job = crew.Job,
                Name = crew.Name
            };
        }
    }
}