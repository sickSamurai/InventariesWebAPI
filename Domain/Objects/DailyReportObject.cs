using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Domain.Objects {
  public class DailyReportObject {
    public TransactionObject[] Transactions { get; set; } = Array.Empty<TransactionObject>();
    public decimal Total { get; set; } = 0;
  }
}
