using System;
using System.Collections.Generic;
using System.ComponentModel;
using wasted_app.Models;
using wasted_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wasted_app.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}