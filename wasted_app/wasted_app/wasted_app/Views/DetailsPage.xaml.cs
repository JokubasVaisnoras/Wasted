using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wasted_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using wasted_app.Database;
using wasted_app.Tables;
using Microsoft.EntityFrameworkCore.Internal;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public DetailsPage()
        {
            InitializeComponent();

            var obj = App.Current as App;
            username.Text = obj.username;
            id.Text = obj.id.ToString();
            email.Text = obj.email;

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
