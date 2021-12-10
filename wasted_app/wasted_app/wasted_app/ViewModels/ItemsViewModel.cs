using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using wasted_app.Models;
using wasted_app.Services;
using wasted_app.Views;
using Xamarin.Forms;

namespace wasted_app.ViewModels
{
    struct NameShop
    {
        public string name_shop;
    }
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        /*private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>((text) =>
                {
                    // The text parameter can now be used for searching.
                }));
            }
        }
        */
        public ItemsViewModel()
        {
            NameShop str = new NameShop();
            str.name_shop = "Shop";
            Title = str.name_shop;
            Items = new ObservableCollection<Item>();
            
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);

                DBAgent databaseAgent = new DBAgent();
                var itemsList = databaseAgent.ShowItems();
                foreach (var item in itemsList)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}