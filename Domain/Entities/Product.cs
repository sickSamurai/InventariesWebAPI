using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventariesWebAPI.Domain.Entities {

  [Table("Product")]
  public class Product {
    [Key] public string Id { get; set; } = "";
    
    public string Name { get; set; } = "";

    public string? Description { get; set; }

    public string Category { get; set; } = "";

    public decimal Price { get; set; } = 0;

    public int Stock { get; set; } = 0;

    public bool Status { get; set; } = true;

    public override bool Equals(object? obj) {
      return obj is Product product && Id == product.Id;
    }

    public override int GetHashCode() {
      return HashCode.Combine(Id);
    }
  }
}
