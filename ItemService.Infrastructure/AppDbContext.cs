using ItemService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemService.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Item> Items => Set<Item>();

        
    }
}