using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace wasted_app.ViewModels
{
    public class CheckoutPage : BaseViewModel
    {
        public CheckoutPage()
        {
            Title = "Checkout";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.paypal.com/lt/home"));
        }
        public ICommand OpenWebCommand { get; }
    }
}
