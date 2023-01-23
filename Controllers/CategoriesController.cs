using InventariesWebAPI.Domain.Responses;
using InventariesWebAPI.Services.CategoriesService;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InventariesWebAPI.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  [EnableCors("MyPolicy")]
  public class CategoriesController : ControllerBase {
    private ICategoriesService CategoriesService;

    public CategoriesController(ICategoriesService categoriesService) {
      CategoriesService = categoriesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
      return Ok(await CategoriesService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryObject category) {
      var Response = await CategoriesService.Create(category);
      if(Response.OperationSuccessful) return Ok(Response);
      return (BadRequest(Response));      
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] CategoryObject category) {
      var Response = await CategoriesService.Edit(category);
      if(Response.OperationSuccessful) return Ok(Response);
      return (BadRequest(Response));
    }

    [HttpDelete("{CategoryId}")]
    public async Task<IActionResult> Delete(string CategoryId) {
      var Response = await CategoriesService.Delete(CategoryId);
      if(Response.OperationSuccessful) return Ok(Response);
      return (BadRequest(Response));      
    }
  }

}