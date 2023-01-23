using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Domain.Objects {
  public class TransactionToSaveObject {  

    public string Product { get; set; } = "";

    public int Units { get; set; } = 0;    
  }
}
