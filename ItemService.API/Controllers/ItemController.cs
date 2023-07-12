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
            return null;
        }
        
        [HttpGet]
        public async Task<object> GetItem(int id)
        {
            return null;
        }

        [HttpPost]
        public async Task<object> AddItem(string name)
        {
            return null;
        }
    }
}