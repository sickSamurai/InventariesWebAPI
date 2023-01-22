using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Domain.Objects {
  public class TransactionToSaveObject {  

    public string Product { get; set; } = "";

    public int Units { get; set; } = 0;

    public decimal? Discount { get; set; } = 0;    
  }
}
