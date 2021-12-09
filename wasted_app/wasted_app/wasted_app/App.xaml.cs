using System;
using wasted_app.Services;
using wasted_app.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wasted_app
{
    public partial class App : Application
    {
        public string username { get; set; }
        public string email { get; set; }
        //public string phonenumber { get; set; }
        public Guid id { get; set; }

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
