using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfoMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchBarLayout : Grid
	{
        #region Bindable Properties

        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(
            propertyName: nameof(SearchCommand),
            returnType: typeof(Command<string>),
            declaringType: typeof(SearchBarLayout),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        #endregion

        #region Properties

        public Command<string> SearchCommand
        {
            get => (Command<string>)GetValue(SearchCommandProperty);
            set => SetValue(SearchCommandProperty, value);
        }

        #endregion

        #region Constructors

        public SearchBarLayout()
		{
			InitializeComponent ();
		}

        #endregion

        #region Private Methods

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e) {
        }
         //   searchBar?.Focus();

        private void SearchBar_SearchButtonPressed(object sender, System.EventArgs e)
        {
            if(sender is SearchBar searchBar)
                SearchCommand?.Execute(searchBar.Text);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e?.NewTextValue))
            {
                if (sender is SearchBar searchBar)
                    searchBar.Unfocus();

                SearchCommand?.Execute(e?.NewTextValue);
            }    
        }

        #endregion
    }
}