using System;
using System.Diagnostics;
using System.Threading.Tasks;
using wasted_app.Models;
using Xamarin.Forms;

namespace wasted_app.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string product;
        private string description;
        private double price;
        private string expiration;
        private string type;
        public string Id { get; set; }

        public string Product
        {
            get => product;
            set => SetProperty(ref product, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public double Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public string Expiration
        {
            get => expiration;
            set => SetProperty(ref expiration, value);
        }

        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Product = item.Product;
                Description = item.Description;
                Price = item.Price;
                Expiration = item.Expiration;
                Type = item.Type;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
