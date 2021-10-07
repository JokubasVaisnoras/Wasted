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
        public INavigation _navigation;
        public ICommand LogoutCommand
        {
            get;
            private set;
        }
        public DetailsPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LogoutCommand = new Command(() => ResetUserInfoAsync());
        }
        async Task ResetUserInfoAsync()
        {
            await Shell.Current.GoToAsync("//LoginPage");

        }
    }
}
