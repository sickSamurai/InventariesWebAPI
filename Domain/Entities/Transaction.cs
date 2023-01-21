using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventariesWebAPI.Domain.Entities {
  [Table("Transaction")]
  public class Transaction {
    [Key] public string Id { get; set; } = "";
    
    public int BillingNumber { get; set; } = 0;

    public String Product { get; set; } = "";

    public decimal Discount { get; set; } = 0;

    public decimal UnitPrice { get; set; } = 0;

    public decimal Subtotal { get; set; } = 0;

    public override bool Equals(object? obj) {
      return obj is Transaction transaction && Id == transaction.Id;
    }

    public override int GetHashCode() {
      return HashCode.Combine(Id);
    }
  }
}
