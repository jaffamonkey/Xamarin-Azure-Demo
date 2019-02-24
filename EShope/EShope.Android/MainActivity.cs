﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading;
using FFImageLoading.Forms.Droid;
using Android.Content.Res;
using EShope.Droid.Services;

namespace EShope.Droid
{
    [Activity(Label = "EShope", Icon = "@mipmap/cart_image", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            DeviceOrientation.NotifyOrientationChange(newConfig);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            //Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            //FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            //FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);

            //var config = new FFImageLoading.Config.Configuration()
            //{
            //    VerboseLogging = false,
            //    VerbosePerformanceLogging = false,
            //    VerboseMemoryCacheLogging = false,
            //    VerboseLoadingCancelledLogging = false,
            //    Logger = new CustomLogger(),
            //};
            //ImageService.Instance.Initialize(config);


            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            //PopupMenu
        }
    }
    public class CustomLogger : FFImageLoading.Helpers.IMiniLogger
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }

        public void Error(string errorMessage, Exception ex)
        {
            Error(errorMessage + System.Environment.NewLine + ex.ToString());
        }
    }
}