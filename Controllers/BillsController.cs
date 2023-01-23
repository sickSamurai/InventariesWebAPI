using InventariesWebAPI.Domain.Objects;
using InventariesWebAPI.Services.BillsService.cs;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InventariesWebAPI.Controllers {
  [Route("api/[controller]")]
  [EnableCors("MyPolicy")]
  public class BillsController : ControllerBase {

    private IBillsService BillsService;

    public BillsController(IBillsService billsService) {
      BillsService = billsService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BillToSaveObject Bill) {
      var Response = await BillsService.Create(Bill);
      if(Response.IsNullOrEmpty()) return BadRequest();
      return Ok(Response);
    }
  }
}
