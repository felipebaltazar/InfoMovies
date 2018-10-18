using InfoMovies.Helpers;

namespace InfoMovies.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        #region Fields

        private string title = string.Empty;
        private bool isBusy = false;

        #endregion

        #region Properties

        /// <summary>
        /// Defines if view is busy
        /// </summary>
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        /// <summary>
        /// View title
        /// </summary>
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        #endregion
    }
}