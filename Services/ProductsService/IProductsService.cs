using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Services.ProductsService {
  public interface IProductsService {
    Task<ProductObject[]> GetAll();
    
    Task<ProductObject[]> GetByCategory(string CategoryId);

    Task<ProductObject> GetById(String Id);

    Task<DbResponse> Create(ProductObject product);
    
    Task<DbResponse> Edit(ProductObject product);    

    Task<DbResponse> Delete(String ProductId);

  }
}
