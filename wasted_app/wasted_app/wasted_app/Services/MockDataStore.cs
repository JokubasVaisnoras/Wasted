using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using wasted_app.Models;

namespace wasted_app.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
       
        public MockDataStore()
        {
            items = new List<Item>();

            //Item item = new Item { Id = Guid.NewGuid().ToString(), Name = "Milk", Description = "From local cows. 3 litres", Price = 2, Expiration = "2021-09-20", Type1 = "Product", Type2 = "Dairy", Amount = 5 };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ItemsDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<Item>();
            db.Insert(item);        

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            /// update the item

            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            /// delete the item

            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ItemsDatabase.db");

            using (var db = new SQLiteConnection(dbpath))
            {
                db.CreateTable<Item>();
                var itemsList = db.Table<Item>().ToList();
                foreach (var item in itemsList)
                {
                    items.Add(item);
                }
            }
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}