
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfoMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopListButton : Button
	{
        private const int ANIMATION_LENGTH = 300;
		public TopListButton ()
		{
			InitializeComponent ();
		}

        private void Button_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(IsVisible)))
            {
                if (IsVisible)
                {
                    this.ScaleTo(0.1, ANIMATION_LENGTH, Easing.SpringOut);
                    this.FadeTo(0, ANIMATION_LENGTH, Easing.SpringOut);
                }
                else
                {
                    this.FadeTo(1, ANIMATION_LENGTH, Easing.SpringOut);
                    this.ScaleTo(1, ANIMATION_LENGTH, Easing.SpringOut);
                }
            }
        }
    }
}