using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wasted_app.Database;
using wasted_app.Tables;
using wasted_app.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

       async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        async void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            var db = new DatabaseContext();
            var myquery = await db.Users.FirstOrDefaultAsync(u => u.Username.Equals(EntryUser.Text) && u.Password.Equals(EntryPassword.Text));

            if (myquery != null)
            {
                var obj = App.Current as App;

                obj.username = myquery.Username;
                obj.email = myquery.Email;
                obj.phonenumber = myquery.PhoneNumber;

                App.Current.MainPage = new AppShell();
            }

            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("ERROR", "Incorrect username/password", "Yes", "Cancel");
                });
            }
        }
    }
}
