using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventariesWebAPI.Domain.Entities {
  [Table("Category")]
  public class Category {
    [StringLength(36)]
    [Key]
    public string Id { get; set; } = "";

    [StringLength(50)]
    public string Name { get; set; } = "";

    [StringLength(500)]
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
