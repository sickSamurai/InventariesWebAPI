using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Domain.Objects {
  public class ProductToSaveObject {
    public string? Id { get; set; } = "";

    public string Name { get; set; } = "";

    public string? Description { get; set; }

    public string Category { get; set; } = "";

    public decimal Price { get; set; } = 0;

    public int Stock { get; set; } = 0;

    public bool Status { get; set; } = true;
  }
}
