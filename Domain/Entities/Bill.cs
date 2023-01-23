using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventariesWebAPI.Domain.Entities {

  [Table("Bill")]
  public class Bill {
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();


    [StringLength(36)] [Required] public string Customer { get; set; } = "";

    [Required] public DateTime CreationDate { get; set; } = DateTime.Today;

    [Required] public DateTime ExpirationDate { get; set; } = DateTime.Today.AddDays(365);    

    [Required] public decimal Total { get; set; } = 0;

    public override bool Equals(object? obj) {
      return obj is Bill bill && Id == bill.Id;
    }

    public override int GetHashCode() {
      return HashCode.Combine(Id);
    }
  }
}
