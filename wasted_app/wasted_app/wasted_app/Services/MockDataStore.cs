using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wasted_app.Models;

namespace wasted_app.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        DBAgent databaseAgent;

        public MockDataStore()
        {
            items = new List<Item>();
            databaseAgent = new DBAgent();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            databaseAgent.AddItemToDB(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            /// update the item

            /*var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);*/

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            /// delete the item

            /*var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);*/

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var itemsList = databaseAgent.ShowItems();
            foreach (var item in itemsList)
            {
                items.Add(item);
            }
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}