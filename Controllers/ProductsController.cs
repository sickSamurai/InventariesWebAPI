using InventariesWebAPI.Domain.Entities;
using InventariesWebAPI.Domain.Objects;
using InventariesWebAPI.Domain.Responses;
using InventariesWebAPI.Services.ProductsService;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InventariesWebAPI.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  [EnableCors("MyPolicy")]
  public class ProductsController : ControllerBase {
    private IProductsService ProductsService;
    
    public ProductsController(IProductsService ProductsService) {
      this.ProductsService = ProductsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
      return Ok(await ProductsService.GetAll());
    }

    [HttpGet("{CategoryId}")]
    public async Task<IActionResult> GetByCategory(string CategoryId) {
      return Ok(await ProductsService.GetByCategory(CategoryId));
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductToSaveObject Product) {
      var Response = await ProductsService.Create(Product);
      if(Response.OperationSuccessful) return Ok(Response);
      return BadRequest(Response);
    }

    [HttpPut]
    public async Task<IActionResult> Edit(ProductToSaveObject Product) {
      var Response = await ProductsService.Edit(Product);
      if(Response.OperationSuccessful) return Ok(Response);
      return BadRequest(Response);
    }

    [HttpDelete("{ProductId}")]
    public async Task<IActionResult> Delete(string ProductId) {
      var Response = await ProductsService.Delete(ProductId);
      if(Response.OperationSuccessful) return Ok(Response);
      return BadRequest(Response);
    }
  }
}