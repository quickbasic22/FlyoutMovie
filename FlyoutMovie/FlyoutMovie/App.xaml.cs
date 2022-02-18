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
        static MockDataStore database;

        public static MockDataStore DataBase
        {
            get
            {
                if (database == null)
                {
                    database = new MockDataStore(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), "Movies.db3"));

                }
                return database;


            }
        }

        public App()
        {
            InitializeComponent();
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
