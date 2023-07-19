using ItemService.Domain.Models;

namespace ItemService.Application;

public interface IItemPersistance
{
    public List<Item> GetItems();
    public Task<Item> GetItemAsync(int id);
    public Task<Item> AddItemAsync(string name);
}