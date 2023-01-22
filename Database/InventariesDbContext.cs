using InventariesWebAPI.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace InventariesWebAPI.Database {
  public class InventariesDbContext : DbContext {
    private IConfiguration configuration;
    public InventariesDbContext(DbContextOptions<InventariesDbContext> options, IConfiguration configuration) : base(options) { 
      this.configuration = configuration;
      if(!this.Database.CanConnect()) new ScriptLoader(configuration).LoadScript();
      
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Bill> Bills { get; set; }

    public DbSet<Transaction> Transactions { get; set; }
  }
}
