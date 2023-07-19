using ItemService.Domain.Models;
using ItemService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemService.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ItemController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        [HttpGet]
        public ActionResult<List<Item>> GetItems()
        {
            var result = _appDbContext.Items.ToList();
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<ActionResult<Item>> GetItemAsync(int id)
        {
            Item? item = await _appDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> AddItemAsync(string name)
        {
            Item item = new(){Name=name};
            await _appDbContext.Items.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return Ok(item);
        }
    }
}