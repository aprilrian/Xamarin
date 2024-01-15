using PBP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBP.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Athiya Puteri Hidayat", Description="24060121140128" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Aprilyanto Setiyawan Siburian", Description="24060121120022" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Christian Joshua Nathanael Nadeak", Description="24060121140120" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fikri Baswara Andanawarih", Description="24060121140122." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Thifa Ziada Taqiyya ", Description="24060121130080" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Zenobia Wirandi Zenaide", Description="24060121140164" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Zhafira Amanda", Description="24060121140100" }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}