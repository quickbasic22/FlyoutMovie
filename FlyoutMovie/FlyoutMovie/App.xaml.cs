using Android.Content.Res;
using FlyoutMovie.Services;
using FlyoutMovie.Views;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace FlyoutMovie
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            
            try
            {
                var mydocuments = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                mydocuments += @"Assets\MoviesDB.db";
                File.Copy("MoviesDB.db", mydocuments);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error Copying File to Android {ex.Message}");

            }
            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart fired.");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep fired.");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume fired.");
        }
    }
}
