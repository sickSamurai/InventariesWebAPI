namespace InventariesWebAPI.Domain.Responses {
  public class ProductObject {
    public string? Id { get; set; }
    public string Name { get; set; } = "";

    public string? Description { get; set; }

    public CategoryObject Category { get; set; } = new CategoryObject();

    public decimal Price { get; set; } = 0;

    public int Stock { get; set; } = 0;

    public bool Status { get; set; } = true;
  }
}
