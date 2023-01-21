using InventariesWebAPI.Database;
using InventariesWebAPI.Domain.Entities;
using InventariesWebAPI.Domain.Responses;

using Microsoft.EntityFrameworkCore;

namespace InventariesWebAPI.Services.CategoriesService {
  public class CategoriesService : ICategoriesService {

    private InventariesDbContext DbContext;

    public CategoriesService(InventariesDbContext dbContext) {
      DbContext = dbContext;
    }

    public async Task<DbResponse> Create(CategoryObject Category) {
      try {
        Category DTO = new Category { Id = Guid.NewGuid().ToString(), Name = Category.Name, Description = Category.Description };
        DbContext.Categories.Add(DTO);
        return new DbResponse { OperationSuccessful = await DbContext.SaveChangesAsync() != 0 };
      } catch(Exception ex) {
        return new DbResponse { OperationSuccessful = false };
      }
    }

    public async Task<DbResponse> Delete(string CategoryId) {
      try {
        DbContext.Categories.Remove(await DbContext.Categories.AsNoTracking().FirstAsync(CategoryOnDb => CategoryOnDb.Id == CategoryId));
        return new DbResponse { OperationSuccessful = await DbContext.SaveChangesAsync() != 0 };
      } catch(Exception) {
        return new DbResponse { OperationSuccessful = false };
      }
    }

    public async Task<DbResponse> Edit(CategoryObject Category) {
      try {
        if(Category.Id == null) throw new Exception("CategoryId can't be null");
        Category DTO = new Category { Id = Category.Id, Description = Category.Description, Name = Category.Name, Status = Category.Status };
        DbContext.Categories.Update(DTO);
        return new DbResponse { OperationSuccessful = await DbContext.SaveChangesAsync() != 0 };
      } catch(Exception) {
        return new DbResponse { OperationSuccessful = false };
      }
    }

    public async Task<CategoryObject[]> GetAll() {
      return (await DbContext.Categories.ToArrayAsync())
        .Select(Category => new CategoryObject {
          Id = Category.Id,
          Name = Category.Name,
          Description = Category.Description,
          Status = Category.Status
        }).ToArray();
    }

    public async Task<CategoryObject> GetById(string CategoryId) {
      var DTO = await DbContext.Categories.FindAsync(CategoryId);
      if(DTO == null) throw new Exception("Category not found");
      return new CategoryObject { Id = DTO.Id, Name = DTO.Name, Description = DTO.Description, Status = DTO.Status };
    }
  }
}
