using InventariesWebAPI.Domain.Objects;
using InventariesWebAPI.Services.BillsService.cs;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InventariesWebAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class BillsController : ControllerBase {

    private IBillsService BillsService;

    public BillsController(IBillsService billsService) {
      BillsService = billsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetByCreationDate(DateTime CreationDate) {
      var Response = await BillsService.GetByCreationDate(CreationDate);
      return Ok(Response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(BillToSaveObject Bill) {
      var Response = await BillsService.Create(Bill);
      if(Response.IsNullOrEmpty()) return BadRequest();
      return Ok(Response);
    }
  }
}
