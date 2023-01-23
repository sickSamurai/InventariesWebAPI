using InventariesWebAPI.Domain.Objects;
using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Services.ProductsService {
  public interface IProductsService {
    Task<ProductObject[]> GetAll();
    
    Task<ProductObject[]> GetByCategory(string CategoryId);

    Task<ProductObject> GetById(String Id);

    Task<DbResponse> Create(ProductToSaveObject product);
    
    Task<DbResponse> Edit(ProductToSaveObject product);    

    Task<DbResponse> Delete(String ProductId);

  }
}
