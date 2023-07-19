using ItemService.Domain.Models;

namespace ItemService.Domain;

public interface IItemRepository{
    public List<Item> GetItems();
    public Task<Item?> GetItemAsync(int id);
    public Task<Item> AddItemAsync(string name);
}