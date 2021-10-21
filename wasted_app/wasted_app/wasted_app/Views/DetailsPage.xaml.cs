using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wasted_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var obj = App.Current as App;
            username.Text = obj.username;
            phonenumber.Text = obj.phonenumber;
            email.Text = obj.email;
        }

        public DetailsPage()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
