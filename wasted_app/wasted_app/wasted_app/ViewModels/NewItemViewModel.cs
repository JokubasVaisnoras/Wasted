using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using wasted_app.Models;
using Xamarin.Forms;

namespace wasted_app.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string product;
        private string description;
        private double price;
        private string expiration;
        private string type;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(product)
                && !String.IsNullOrWhiteSpace(description)
                && !String.IsNullOrWhiteSpace(expiration)
                && !String.IsNullOrWhiteSpace(type);
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Product = Product,
                Description = Description,
                Price = Price,
                Expiration = Expiration,
                Type = Type
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
