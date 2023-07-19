﻿using ItemService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Item> Items => Set<Item>();

        
    }
}