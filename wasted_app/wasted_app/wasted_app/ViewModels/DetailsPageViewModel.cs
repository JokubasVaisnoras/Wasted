using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using wasted_app.Views;
using Xamarin.Forms;


namespace wasted_app.ViewModels
{
    public class DetailsPageViewModel
    { 
        public ICommand LogoutCommand
        {
            get;
            private set;
        }
        public DetailsPageViewModel()
        {
            LogoutCommand = new Command(async () => await ResetUserInfoAsync());
        }
        async Task ResetUserInfoAsync()
        {
            await Shell.Current.GoToAsync("//LoginPage");

        }
    }
}
