using ItemService.Domain;
using ItemService.Domain.Models;

namespace ItemService.Application;

public class ItemRepository : ItemService.Domain.IItemRepository
{
    private IItemPersistance _itemPersistance { get; }
    public ItemRepository(IItemPersistance itemPersistance)
    {
        _itemPersistance = itemPersistance;
    }

    public List<Item> GetItems()
    {
        return _itemPersistance.GetItems();
    }

    public Task<Item> GetItemAsync(int id)
    {
        return _itemPersistance.GetItemAsync(id);
    }

    public Task<Item> AddItemAsync(string name)
    {
        return _itemPersistance.AddItemAsync(name);
    }
}
