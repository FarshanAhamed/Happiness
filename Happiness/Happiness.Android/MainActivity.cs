﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Happiness.Droid.Renderers;

namespace Happiness.Droid
{
    [Activity(Label = "Happiness", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        private bool _lieAboutCurrentFocus;
        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            var focused = CurrentFocus;
            bool customEntryRendererFocused = focused != null && focused.Parent is CoolEntryRenderer;

            _lieAboutCurrentFocus = customEntryRendererFocused;
            var result = base.DispatchTouchEvent(ev);
            _lieAboutCurrentFocus = false;

            return result;
        }

        public override View CurrentFocus
        {
            get
            {
                if (_lieAboutCurrentFocus)
                {
                    return null;
                }

                return base.CurrentFocus;
            }
        }


    }
}