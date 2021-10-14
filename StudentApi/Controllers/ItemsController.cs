using Microsoft.AspNetCore.Mvc;
using StudentApi.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentApi.DTOs;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    //GET /items
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository<Item> repository;

        public ItemsController(IItemsRepository<Item> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await repository.GetAllAsync())
            .Select(x=>new ItemDto{
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                CreatedDate = x.CreatedDate
            });
            return items;
        }
        //GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
        //POST
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            await repository.CreateAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id}, item.AsDto());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await repository.GetAsync(id);
            if(existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            await repository.UpdateAsync(updatedItem);
            return NoContent();
        }
        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await repository.GetAsync(id);
            if(existingItem is null)
            {
                return NotFound();
            }


            await repository.DeleteAsync(id);
            return NoContent();
        }
    }
}