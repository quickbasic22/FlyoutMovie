using System.Diagnostics;
using Xamarin.Forms;

namespace FlyoutMovie
{
    public partial class App : Application
    {
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
