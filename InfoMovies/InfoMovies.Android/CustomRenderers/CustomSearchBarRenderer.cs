using Android.Content;
using InfoMovies.Droid.CustomRenderers;
using InfoMovies.Helpers;
using InfoMovies.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace InfoMovies.Droid.CustomRenderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        #region Constructors

        public CustomSearchBarRenderer(Context context) : base(context)
        { }

        #endregion

        #region Overrides

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            try
            {
                if (Control != null)
                {
                    var plateId = Resources.GetIdentifier("android:id/search_plate", null, null);
                    var plate = Control.FindViewById(plateId);
                    plate.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }
        }

        #endregion
    }
}