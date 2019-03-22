using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleCalc.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalcButton : ContentView
    {
        public CalcButton()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public event EventHandler OnTapped;

        public static readonly new BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(CalcButton), Color.White);
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CalcButton), null);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(CalcButton), 18d);

        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            new Animation
                {
                    { 0d, .5d , new Animation(i => Scale = i, 1d, .9d) },
                    { .5d, 1d , new Animation(i => Scale = i, .9d, 1d) },
                }.Commit(this, "ClickAnimation", 16, 200, Easing.CubicInOut);

            OnTapped?.Invoke(this, EventArgs.Empty);
        }
    }
}