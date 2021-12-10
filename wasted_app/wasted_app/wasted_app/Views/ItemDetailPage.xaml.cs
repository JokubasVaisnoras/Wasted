using System;
using System.ComponentModel;
using wasted_app.Services;
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
            
            DBAgent databaseAgent = new DBAgent();
            databaseAgent.DeleteItem(ItemNameLabel.Text);

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Item deleted!", "", "OK", " ");
                if (result)
                    await Navigation.PushAsync(new ItemsPage());
            });
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            // should be a normal page for collecting the text for update

            DBAgent databaseAgent = new DBAgent();
            databaseAgent.UpdateItemDescription(ItemNameLabel.Text, "Very delicious, my neighbour loved it.");

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Item's description updated!", "", "OK", " ");
                if (result)
                    await Navigation.PushAsync(new ItemsPage());
            });
        }
    }
}