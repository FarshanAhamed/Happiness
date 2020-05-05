using FFImageLoading.Svg.Forms;
using Happiness.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Happiness.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordEntry : Grid
    {
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), 
            typeof(string), typeof(CoolEntry), default(string), BindingMode.OneWay);
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
            typeof(string), typeof(CoolEntry), default(string), BindingMode.TwoWay);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon),
            typeof(string), typeof(SvgCachedImage), default(string), BindingMode.OneWay);
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly BindableProperty HideIconProperty = BindableProperty.Create(nameof(HideIcon),
            typeof(string), typeof(SvgCachedImage), default(string), BindingMode.OneWay);
        public string HideIcon
        {
            get => (string)GetValue(HideIconProperty);
            set => SetValue(HideIconProperty, value);
        }

        public static readonly BindableProperty IconScaleProperty = BindableProperty.Create(nameof(IconScale),
            typeof(string), typeof(SvgCachedImage), default(string), BindingMode.OneWay);
        public string IconScale
        {
            get => (string)GetValue(IconScaleProperty);
            set => SetValue(IconScaleProperty, value);
        }

        public static readonly BindableProperty IconOpacityProperty = BindableProperty.Create(nameof(IconOpacity),
           typeof(string), typeof(SvgCachedImage), default(string), BindingMode.OneWay);
        public string IconOpacity
        {
            get => (string)GetValue(IconOpacityProperty);
            set => SetValue(IconOpacityProperty, value);
        }

        public static readonly BindableProperty HintProperty = BindableProperty.Create(nameof(Hint),
           typeof(string), typeof(Label), default(string), BindingMode.OneWay);
        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set => SetValue(HintProperty, value);
        }

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius),
           typeof(string), typeof(Frame), default(string), BindingMode.OneWay);
        public string CornerRadius
        {
            get => (string)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly BindableProperty FramePaddingProperty = BindableProperty.Create(nameof(FramePadding),
           typeof(Thickness), typeof(Frame), new Thickness(0), BindingMode.OneWay);
        public Thickness FramePadding
        {
            get => (Thickness)GetValue(FramePaddingProperty);
            set => SetValue(FramePaddingProperty, value);
        }

        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor),
           typeof(Color), typeof(Frame), Color.Transparent, BindingMode.OneWay);
        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public static readonly BindableProperty HintColorProperty = BindableProperty.Create(nameof(HintColor),
           typeof(Color), typeof(Label), Color.Default, BindingMode.OneWay);
        public Color HintColor
        {
            get => (Color)GetValue(HintColorProperty);
            set => SetValue(HintColorProperty, value);
        }

        public PasswordEntry()
        {
            InitializeComponent();
            passEntry.Placeholder = Placeholder;
            passEntry.Text = Text;
            passEntry.TextChanged += PassEntry_TextChanged;
            icon.Source = Icon;
            SetScale(IconScale);
            SetOpacity(IconOpacity);
            SetHint(Hint);
            SetCornerRadius(CornerRadius);
            SetFramePadding(FramePadding);
            passFrame.BackgroundColor = BackgroundColor;
            passHint.TextColor = HintColor;
        }

        private void SetHint(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                passHint.IsVisible = false;
            else
            {
                passHint.Text = value;
                passHint.IsVisible = true;
            }
        }

        private void SetCornerRadius(string value)
        {
            if (float.TryParse(value, out float radius))
            {
                passFrame.CornerRadius = radius == default ? 1 : radius;
            }
            else
                passFrame.CornerRadius = 0;
        }

        private void SetFramePadding(string value)
        {
            if (double.TryParse(value, out double padding) && padding != default)
            {
                passFrame.Padding = new Thickness(padding);
                passHint.Padding = new Thickness(padding, 0, 0, 0);
            }
            else
            {
                passFrame.Padding = new Thickness(0);
                passHint.Padding = new Thickness(5, 0, 0, 0);
            }
        }

        private void SetFramePadding(Thickness value)
        {
            passFrame.Padding = value;
            passHint.Padding = new Thickness((value.Left), 0, 0, 0);
        }


        private void SetScale(string value)
        {
            if (double.TryParse(value, out double scale))
            {
                icon.Scale = scale == default ? 1 : scale;
            }
            else
                icon.Scale = 1;
        }

        private void SetOpacity(string value)
        {
            if (double.TryParse(value, out double opacity))
            {
                icon.Opacity = opacity == default ? 1 : opacity;
            }
            else
                icon.Scale = 1;
        }

        private void PassEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text = e.NewTextValue;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == PlaceholderProperty.PropertyName)
            {
                passEntry.Placeholder = Placeholder;
            }
            else if (propertyName == TextProperty.PropertyName)
            {
                passEntry.Text = Text;
            }
            else if (propertyName == IconProperty.PropertyName)
            {
                icon.Source = Icon;
            }
            else if (propertyName == IconScaleProperty.PropertyName)
            {
                SetScale(IconScale);
            }
            else if (propertyName == IconOpacityProperty.PropertyName)
            {
                SetOpacity(IconOpacity);
            }
            else if (propertyName == HintProperty.PropertyName)
            {
                SetHint(Hint);
            }
            else if (propertyName == CornerRadiusProperty.PropertyName)
            {
                SetCornerRadius(CornerRadius);
            }
            else if (propertyName == FramePaddingProperty.PropertyName)
            {
                SetFramePadding(FramePadding);
            }
            else if (propertyName == BackgroundColorProperty.PropertyName)
            {
                passFrame.BackgroundColor = BackgroundColor;
            }
            else if (propertyName == HintColorProperty.PropertyName)
            {
                passHint.TextColor = HintColor;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bool isPassword = passEntry.IsPassword;

            if(string.IsNullOrWhiteSpace(HideIcon) == false)
            {
                if (isPassword)
                    icon.Source = HideIcon;
                else
                    icon.Source = Icon;
            }

            var position = passEntry.CursorPosition;
            passEntry.IsPassword = !isPassword;
            passEntry.CursorPosition = position;
            
        }
    }
}