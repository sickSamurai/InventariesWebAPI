namespace InventariesWebAPI.Domain.Responses {
  public class TransactionObject {
    public string? Id { get; set; }

    public ProductObject Product { get; set; } = new ProductObject();

    public int Units { get; set; } = 0;        

    public decimal Subtotal { get; set; } = 0;    

  }
}
