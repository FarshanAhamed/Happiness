using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Happiness
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();

            var animation = new Animation {
                { 0, 1, new Animation(_ => footer.TranslateTo(0, 0, 2500, Easing.CubicInOut)) },
                { 0, 1, new Animation(_ => footer.FadeTo(1, 5000, Easing.Linear)) }
            };

            animation.Commit(this, "Footer");

        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            var animation = new Animation {
                { 0, 1, new Animation(_ => image.FadeTo(0, 2000, Easing.CubicInOut)) },
                { 0, 1, new Animation(_ => head.FadeTo(0, 2000, Easing.CubicInOut)) },
                { 0.5, 1, new Animation(_ => userEntry.TranslateTo(-500, 0, 2000, Easing.CubicInOut)) },
                { 0.5, 1, new Animation(_ => passwordEntry.TranslateTo(500, 0, 2000, Easing.CubicInOut)) },
                { 0.8, 1, new Animation(_ => footer.TranslateTo(0, 500, 2500, Easing.CubicInOut)) },
                { 0.8, 1, new Animation(_ => mainGrid.FadeTo(0, 4000, Easing.CubicInOut)) },
                { 0.9, 1, new Animation(_ => hole.FadeTo(1, 3000, Easing.CubicInOut)) },
                { 0, 1, new Animation(_ => mainPart.FadeTo(1, 5000, Easing.CubicInOut)) }
            };

            animation.Commit(this, "main");
        }
    }
}
