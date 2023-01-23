using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Domain.Objects {
  public class BillToSaveObject {     
    public string Customer { get; set; } = "";

    public TransactionToSaveObject[] Transactions { get; set; } = Array.Empty<TransactionToSaveObject>();        
  }
}
