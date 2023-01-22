using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventariesWebAPI.Domain.Entities {

  [Table("Bill")]
  public class Bill {
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();
        
    public string Customer { get; set; } = "";

    public DateTime CreationDate { get; set; } = DateTime.Today;

    public DateTime ExpirationDate { get; set; } = DateTime.Today.AddDays(365);

    public string Observations { get; set; } = "";

    public decimal Total { get; set; } = 0;

    public override bool Equals(object? obj) {
      return obj is Bill bill && Id == bill.Id;
    }

    public override int GetHashCode() {
      return HashCode.Combine(Id);
    }
  }
}
