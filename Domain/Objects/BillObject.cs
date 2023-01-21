using System.ComponentModel.DataAnnotations;

namespace InventariesWebAPI.Domain.Responses {
  public class BillObject {
    public int Id { get; set; } = 0;

    public CustomerObject Customer { get; set; } = new CustomerObject();

    public TransactionObject[] Transactions { get; set; } = Array.Empty<TransactionObject>();

    public DateTime CreationDate { get; set; } = new DateTime();

    public DateTime ExpirationDate { get; set; } = new DateTime();

    public string Observations { get; set; } = "";

    public decimal Total { get; set; } = 0;
  }
}
