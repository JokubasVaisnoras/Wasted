using System;
using System.ComponentModel;
using wasted_app.ViewModels;
using Xamarin.Forms;

namespace wasted_app.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        void OnItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;

            //DELETE HERE

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Item deleted!", "", "OK", " ");
                if (result)
                    await Navigation.PushAsync(new ItemsPage());
            });
        }
    }
}