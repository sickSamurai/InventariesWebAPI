using InventariesWebAPI.Domain.Responses;
using InventariesWebAPI.Services.CustomerService.cs;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InventariesWebAPI.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  [EnableCors("MyPolicy")]
  public class CustomersController: ControllerBase {
    private ICustomerService CustomerService;
    
    public CustomersController(ICustomerService CustomerService) {
      this.CustomerService = CustomerService;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(String Id) {
      return Ok(await this.CustomerService.GetById(Id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CustomerObject Customer) {
      var Response = await CustomerService.Create(Customer);
      if(Response.OperationSuccessful) return Ok(Response);
      else return BadRequest(Response);
    }

    [HttpPut]
    public async Task<IActionResult> Edit(CustomerObject Customer) {
      var Response = await CustomerService.Edit(Customer);
      if(Response.OperationSuccessful) return Ok(Response);
      else return BadRequest(Response);
    }
  }
}
