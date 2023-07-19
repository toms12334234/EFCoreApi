using Microsoft.EntityFrameworkCore;
using ItemService.Application;
using ItemService.Domain.Models;

namespace ItemService.Infrastructure;

public class ItemPersistance : IItemPersistance
{

    private readonly AppDbContext _appDbContext;

    public ItemPersistance(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Item> GetItems()
    {
        return _appDbContext.Items.ToList();
    }

    public async Task<Item?> GetItemAsync(int id)
    {
        return await _appDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Item> AddItemAsync(string name)
    {
        Item item = new() { Name = name };
        await _appDbContext.Items.AddAsync(item);
        await _appDbContext.SaveChangesAsync();
        return item;
    }
}