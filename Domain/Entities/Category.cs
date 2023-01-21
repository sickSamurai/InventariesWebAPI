using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventariesWebAPI.Domain.Entities {
  [Table("Category")]
  public class Category {
    [Key] public string Id { get; set; } = "";

    public string Name { get; set; } = "";

    public string? Description { get; set; } = "";

    public bool Status { get; set; } = true;

    public override bool Equals(object? obj) {
      return obj is Category category && Id == category.Id;
    }

    public override int GetHashCode() {
      return HashCode.Combine(Id);
    }
  }
}
