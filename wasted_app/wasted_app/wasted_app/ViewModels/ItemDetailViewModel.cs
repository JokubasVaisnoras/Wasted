using System;
using System.Diagnostics;
using System.Threading.Tasks;
using wasted_app.Models;
using wasted_app.Services;
using Xamarin.Forms;

namespace wasted_app.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        //public Command DeleteItemCommand { get; }

        private string itemId;
        private string name;
        private string description;
        private double price;
        private string expiration;
        private string type1;
        private string type2;
        private int amount;
        public string Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
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

        public string Type1
        {
            get => type1;
            set => SetProperty(ref type1, value);
        }

        public string Type2
        {
            get => type2;
            set => SetProperty(ref type2, value);
        }

        public int Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
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

        /*public ItemDetailViewModel()
        {
            DeleteItemCommand = new Command(DeleteItem);
        }

        private async void DeleteItem(object obj)
        {
            DBAgent databaseAgent = new DBAgent();
            await databaseAgent.DeleteItem();
        }*/

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                Price = item.Price;
                Expiration = item.Expiration;
                Type1 = item.Type1;
                Type2 = item.Type2;
                Amount = item.Amount;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
