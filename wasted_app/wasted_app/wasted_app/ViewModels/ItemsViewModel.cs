using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using wasted_app.Models;
using wasted_app.Views;
using Xamarin.Forms;

namespace wasted_app.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Review your items";
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
                
                var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ItemsDatabase.db");

                using (var db = new SQLiteConnection(dbpath))
                {
                    db.CreateTable<Item>();
                    var itemsList = db.Table<Item>().ToList();
                    foreach (Object item in itemsList)
                    {
                        Items.Add((Item)item);
                    }
                }
                /*IFormatter formatter = new BinaryFormatter();
                string txtpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "items.txt");
                Stream stream = new FileStream(txtpath, FileMode.Open, FileAccess.Read, FileShare.Read);
                items = (Item)formatter.Deserialize(stream);
                stream.Close();*/
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