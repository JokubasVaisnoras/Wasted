using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using wasted_app.Models;
using Xamarin.Forms;

namespace wasted_app.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string name;
        private string description;
        private double price;
        private string expiration;
        private string type1;
        private string type2;
        private int amount;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description)
                && !String.IsNullOrWhiteSpace(expiration)
                && !String.IsNullOrWhiteSpace(type1)
                && !String.IsNullOrWhiteSpace(type2)
                && 0 < amount && amount < 20;
        }

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
                Name = Name,
                Description = Description,
                Price = Price,
                Expiration = Expiration,
                Type1 = Type1,
                Type2 = Type2,
                Amount = Amount
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

    }
}
