using ItemService.Data;
using ItemService.Data.Models;
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
        public async Task<object> GetItems()
        {
            return _appDbContext.Items;
        }
        
        [HttpGet]
        public async Task<object> GetItem(int id)
        {
            Item item = _appDbContext.Items.FirstOrDefault(x=>x.Id == id);
            return item != null 
                ? new OkObjectResult(item)
                : new NotFoundResult();
        }

        [HttpPost]
        public async Task<object> AddItem(string name)
        {
            Item item = new Item(){Name=name};
            await _appDbContext.Items.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return Created("this", item);
        }
    }
}