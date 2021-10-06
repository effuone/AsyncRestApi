using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApi.Models;
using StudentApi.Repositories;

namespace StudentApi.Repositories
{
    
    public class InMemItemsRepository : IItemsRepository<Item>
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
        };
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await Task.FromResult(items);
        }
        public async Task<Item> GetAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}