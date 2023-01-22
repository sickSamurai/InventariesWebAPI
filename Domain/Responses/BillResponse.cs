namespace InventariesWebAPI.Domain.Responses {
  public class BillResponse {
    public TransactionResults[] TransactionsResponses { get; set; } = Array.Empty<TransactionResults>();
  }
}
