
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfoMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomSearchBar : SearchBar
	{
		public CustomSearchBar ()
		{
			InitializeComponent ();
		}
	}
}