﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentSucessPage : ContentPage
    {
        public PaymentSucessPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new UserItemPage());
        }
    }
}