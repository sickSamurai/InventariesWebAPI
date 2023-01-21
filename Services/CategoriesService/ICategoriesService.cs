using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Services.CategoriesService {
  public interface ICategoriesService {
    Task<CategoryObject[]> GetAll();

    Task<CategoryObject> GetById(String CategoryId);

    Task<DbResponse> Create(CategoryObject Category);

    Task<DbResponse> Edit(CategoryObject Category);

    Task<DbResponse> Delete(String CategoryId);
  }
}
