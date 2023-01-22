namespace InventariesWebAPI.Domain.Responses {
  public class TransactionResults {
    public string ProductName { get; set; } = "";
    
    public bool ProductAvailable { get; set; } = false;

    public bool NameIsRepeated { get; set; } = false;
  }
}
