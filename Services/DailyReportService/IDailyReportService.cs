using InventariesWebAPI.Domain;
using InventariesWebAPI.Domain.Objects;

namespace InventariesWebAPI.Services.DailyReportService.cs {
  public interface IDailyReportService {
    Task<DailyReportObject> GetDailyReport();
  }
}
