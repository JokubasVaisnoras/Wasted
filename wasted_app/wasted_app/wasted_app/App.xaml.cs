using System;
using wasted_app.Services;
using wasted_app.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wasted_app
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
