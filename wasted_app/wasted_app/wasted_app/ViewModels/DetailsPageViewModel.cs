using System;
using System.Collections.Generic;
using System.Text;
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
            LogoutCommand = new Command(() => ResetUserInfo());
        }
        void ResetUserInfo()
        {
            _navigation.PushAsync(new LoginPage());
            
        }
    }
}
