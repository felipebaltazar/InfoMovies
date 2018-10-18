using InfoMovies.Helpers;
using InfoMovies.ViewModels;
using InfoMovies.Views;
using System;
using System.Collections;
using Xamarin.Forms;

namespace InfoMovies
{
    public partial class MainPage : BasePage
    {
        #region Fields

        private MainPageViewModel viewModel;

        #endregion

        #region Constructors

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel();
            InitializeItemsAsync();
        }

        #endregion

        #region Overrides

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LogHelper.TrackEvent("App initialized");
        }

        #endregion

        #region Private Methods

        private async void InitializeItemsAsync()=>
            await viewModel.LoadItemsAsync();

        private async void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (sender is ListView listView)
            {
                var items = listView.ItemsSource as IList;
                if(!(items?.Count > 0))
                    return;

                var lastItem = items[items.Count- 1];
                if (e.Item == lastItem && !IsBusy)
                {
                    if (viewModel.IsSearching)
                        await viewModel.LoadSearchItemsAsync();
                    else
                        await viewModel.LoadItemsAsync();
                }

                var firstItem = items[0];
                if (e.Item == firstItem)
                    topListButton.IsVisible = false;
            }
        }

        private void MoviesListView_ItemDisappearing(object sender, ItemVisibilityEventArgs e)
        {
            if (sender is ListView listView)
            {
                var items = listView.ItemsSource as IList;
                if (!(items?.Count > 0))
                    return;

                var item = items.Count > 5 ? items[5] : items[0];
                if (e.Item == item)
                    topListButton.IsVisible = true;
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null) return;

            //Hack: Remove highlight on listview
            ((ListView)sender).SelectedItem = null;
        }

        private void TopListButton_Pressed(object sender, System.EventArgs e)
        {
            try
            {
                var items = moviesListView.ItemsSource as IList;
                if (!(items?.Count > 0))
                    return;

                var firstItem = items[0];
                moviesListView.ScrollTo(firstItem, ScrollToPosition.Start, true);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }
        }

        private async void MoviesListView_ItemTapped(object sender, ItemTappedEventArgs e) =>
            await NavigationHelper.PushAsync(new ItemDetailsPage(e.Item));

        #endregion
    }
}