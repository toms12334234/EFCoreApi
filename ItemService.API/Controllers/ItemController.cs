using ItemService.Domain;
using ItemService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        
        [HttpGet]
        public ActionResult<List<Item>> GetItems()
        {
            var result = _itemRepository.GetItems();
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<ActionResult<Item>> GetItemAsync(int id)
        {
            Item? item = await _itemRepository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> AddItemAsync(string name)
        {
            Item item = await _itemRepository.AddItemAsync(name);
            return Ok(item);
        }
    }
}