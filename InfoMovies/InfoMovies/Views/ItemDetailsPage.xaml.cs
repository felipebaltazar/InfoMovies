using InfoMovies.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfoMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailsPage : BasePage
	{
		public ItemDetailsPage (object viewModel)
		{
            BindingContext = viewModel;
            FillDetailsAsync();
            InitializeComponent ();
		}

        private async void FillDetailsAsync()
        {
            if(BindingContext is MovieViewModel movieVM)
            {
                await movieVM.GetDetailsAsync();
            }
        }

        private void ListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            //Hack: Remove highlight on listview
            ((ListView)sender).SelectedItem = null;
        }
    }
}