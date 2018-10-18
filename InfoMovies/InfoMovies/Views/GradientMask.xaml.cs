
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfoMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GradientMask : BoxView
	{
        #region Bindable Properties

        public static readonly BindableProperty TopColorProperty = BindableProperty.Create(
            propertyName: nameof(TopColor),
            returnType: typeof(Color),
            declaringType: typeof(GradientMask),
            defaultValue: Color.Transparent,
            defaultBindingMode: BindingMode.OneWay);

        public static readonly BindableProperty BottomColorProperty = BindableProperty.Create(
            propertyName: nameof(BottomColor),
            returnType: typeof(Color),
            declaringType: typeof(GradientMask),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.OneWay);

        #endregion

        #region Properties

        public Color TopColor
        {
            get => (Color)GetValue(TopColorProperty);
            set => SetValue(TopColorProperty, value);
        }

        public Color BottomColor
        {
            get => (Color)GetValue(BottomColorProperty);
            set => SetValue(BottomColorProperty, value);
        }

        #endregion

        #region Constructors

        public GradientMask()
        {
            InitializeComponent();
        }

        #endregion
    }
}