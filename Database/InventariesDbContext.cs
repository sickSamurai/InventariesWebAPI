﻿using InventariesWebAPI.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace InventariesWebAPI.Database {
  public class InventariesDbContext : DbContext {
    public InventariesDbContext(DbContextOptions<InventariesDbContext> options) : base(options) { 
      if(this.Database.CanConnect()) {
        Console.WriteLine("Can Connect");
      }
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Bill> Bills { get; set; }

    public DbSet<Transaction> Transactions { get; set; }
  }
}
