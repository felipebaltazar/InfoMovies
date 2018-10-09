using InfoMovies.Helpers;

namespace InfoMovies.ViewModels
{
    public class CreditsViewModel : BaseViewModel
    {
        private ObservableRangeCollection<CastViewModel> castCollection;
        private ObservableRangeCollection<CrewViewModel> crewCollection;

        public ObservableRangeCollection<CastViewModel> CastCollection
        {
            get => castCollection;
            set => SetProperty(ref castCollection, value);
        }

        public ObservableRangeCollection<CrewViewModel> CrewCollection
        {
            get => crewCollection;
            set => SetProperty(ref crewCollection, value);
        }
    }

    public class CastViewModel : BaseViewModel
    {
        private string character = string.Empty;
        private string name = string.Empty;
        private string profilepath = string.Empty;

        public string Character
        {
            get => character;
            set => SetProperty(ref character, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string ProfilePath
        {
            get => profilepath;
            set => SetProperty(ref profilepath, value);
        }
    }

    public class CrewViewModel : BaseViewModel
    {
        private string job = string.Empty;
        private string name = string.Empty;

        public string Job
        {
            get => job;
            set => SetProperty(ref job, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
    }
}
