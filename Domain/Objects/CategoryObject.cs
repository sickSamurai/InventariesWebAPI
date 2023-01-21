namespace InventariesWebAPI.Domain.Responses {
  public class CategoryObject {
    public string? Id { get; set; }
    public string Name { get; set; } = "";
    
    public string? Description { get; set; }

    public bool Status { get; set; } = true;
  }
}
