using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventariesWebAPI.Domain.Entities {
  [Table("Customer")]
  public class Customer {

    [Key] public string Id { get; set; } ="";
    
    public string Name { get; set; } = "";    

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public override bool Equals(object? obj) {
      return obj is Customer customer && Id == customer.Id;
    }

    public override int GetHashCode() {
      return HashCode.Combine(Id);
    }
  }
}
