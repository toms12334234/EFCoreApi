using Microsoft.AspNetCore.Mvc;

namespace ItemService.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        public async Task<object> GetItems()
        {
            return await Task.FromResult("Hello");
        }
        
        [HttpGet]
        public async Task<object> GetItem(int id)
        {
            return await Task.FromResult("Hello");
        }

        [HttpPost]
        public async Task<object> AddItem(string name)
        {
            return await Task.FromResult("Hello");
        }
    }
}