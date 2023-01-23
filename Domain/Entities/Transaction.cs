using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventariesWebAPI.Domain.Entities {
  [Table("Transaction")]
  public class Transaction {
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();
    
    public string Bill { get; set; } = "";

    public string Product { get; set; } = "";

    public int Units { get; set; } = 0;        

    public decimal Subtotal { get; set; } = 0;

    public override bool Equals(object? obj) {
      return obj is Transaction transaction && Id == transaction.Id;
    }

    public override int GetHashCode() {
      return HashCode.Combine(Id);
    }
  }
}
