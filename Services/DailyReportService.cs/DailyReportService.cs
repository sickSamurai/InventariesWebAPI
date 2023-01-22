using InventariesWebAPI.Database;
using InventariesWebAPI.Domain.Objects;
using InventariesWebAPI.Domain.Responses;
using InventariesWebAPI.Services.BillsService.cs;
using InventariesWebAPI.Services.TransactionsService;

namespace InventariesWebAPI.Services.DailyReportService.cs {
  public class DailyReportService : IDailyReportService {
    private IBillsService BillsService;

    public DailyReportService(InventariesDbContext dbContext, IBillsService BillsService, ITransactionsService TransactionService) {
      this.BillsService = BillsService;
    }

    public async Task<DailyReportObject> GetDailyReport() {
      List<TransactionObject> Transactions = new();
      var BillsOnDay = await BillsService.GetByCreationDate(DateTime.Today);
      decimal Total = 0;

      foreach(var Bill in BillsOnDay) {
        Transactions.AddRange(Bill.Transactions);
        Total += Bill.Total;
      }

      return new DailyReportObject { Total = Total, Transactions = Transactions.ToArray() };
    }
  }
}
