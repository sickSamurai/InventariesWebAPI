using System.ComponentModel.DataAnnotations;

namespace InventariesWebAPI.Domain.Responses {
  public class BillObject {
    public string Id { get; set; } = "";       

    public CustomerObject Customer { get; set; } = new CustomerObject();

    public TransactionObject[] Transactions { get; set; } = Array.Empty<TransactionObject>();

    public DateTime CreationDate { get; set; } = new DateTime();

    public DateTime ExpirationDate { get; set; } = new DateTime();    

    public decimal Total { get; set; } = 0;
  }
}
