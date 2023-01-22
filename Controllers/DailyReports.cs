using InventariesWebAPI.Services.DailyReportService.cs;

using Microsoft.AspNetCore.Mvc;

namespace InventariesWebAPI.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class DailyReportsController : ControllerBase {
    private IDailyReportService DailyReportService;

    public DailyReportsController(IDailyReportService dailyReportService) {
      this.DailyReportService = dailyReportService;
    }

    [HttpGet]
    public async Task<IActionResult> Get() {
      return Ok(await this.DailyReportService.GetDailyReport());
    }
  }
}
