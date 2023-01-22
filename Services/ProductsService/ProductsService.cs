using InventariesWebAPI.Database;
using InventariesWebAPI.Domain.Entities;
using InventariesWebAPI.Domain.Responses;
using InventariesWebAPI.Services.CategoriesService;

using Microsoft.EntityFrameworkCore;

namespace InventariesWebAPI.Services.ProductsService {
  public class ProductsService : IProductsService {

    private InventariesDbContext DbContext;
    private ICategoriesService CategoriesService;

    public ProductsService(InventariesDbContext dbContext, ICategoriesService categoriesService) {
      DbContext = dbContext;
      CategoriesService = categoriesService;
    }

    public async Task<DbResponse> Create(ProductObject product) {
      DbContext.Products.Add(new Product {
        Id = Guid.NewGuid().ToString(),
        Name = product.Name,
        Description = product.Description,
        Category = product.Category.Id,
        Price = product.Price,
        Stock = product.Stock,
        Status = product.Status
      });

      return new DbResponse { OperationSuccessful = await DbContext.SaveChangesAsync() != 0 };
    }


    public async Task<DbResponse> Delete(string ProductId) {
      try {
        var DTO = await DbContext.Products.AsNoTracking().FirstAsync(Product => Product.Id == ProductId);
        DbContext.Products.Remove(DTO);
        return new DbResponse { OperationSuccessful = await DbContext.SaveChangesAsync() != 0 };
      } catch(Exception ex) {
        return new DbResponse { OperationSuccessful = false };
      }
    }

    public async Task<DbResponse> Edit(ProductObject product) {
      try {
        DbContext.Products.Update(new Product {
          Id = product.Id,
          Name = product.Name,
          Description = product.Description,
          Category = product.Category.Id,
          Price = product.Price,
          Stock = product.Stock,
          Status = product.Status
        });
        return new DbResponse { OperationSuccessful = await DbContext.SaveChangesAsync() != 0 };
      } catch(Exception ex) {
        return new DbResponse { OperationSuccessful = false };
      }
    }

    public async Task<ProductObject[]> GetAll() {
      var ProductsDTO = await DbContext.Products.ToArrayAsync();
      List<ProductObject> Products = new();

      foreach(var ProductDTO in ProductsDTO) {
        Products.Add(new ProductObject {
          Id = ProductDTO.Id,
          Name = ProductDTO.Name,
          Description = ProductDTO.Description,
          Category = await CategoriesService.GetById(ProductDTO.Category),
          Price = ProductDTO.Price,
          Stock = ProductDTO.Stock,
          Status = ProductDTO.Status
        });
      }

      return Products.ToArray();
    }

    public async Task<ProductObject[]> GetByCategory(string CategoryId) {
      var ProductsDTO = await DbContext.Products.Where(Product => Product.Category == CategoryId).ToArrayAsync();
      List<ProductObject> Products = new();

      foreach(var ProductDTO in ProductsDTO) {
        Products.Add(new ProductObject {
          Id = ProductDTO.Id,
          Name = ProductDTO.Name,
          Description = ProductDTO.Description,
          Category = await CategoriesService.GetById(CategoryId),
          Price = ProductDTO.Price,
          Stock = ProductDTO.Stock,
          Status = ProductDTO.Status
        });
      }

      return Products.ToArray();
    }

    public async Task<ProductObject> GetById(string Id) {
      var ProductDTO = await DbContext.Products.FindAsync(Id);      
      if(ProductDTO == null) throw new Exception("The product don't exists");
      return new ProductObject {
        Id = ProductDTO.Id,
        Name = ProductDTO.Name,
        Description = ProductDTO.Description,
        Category = await CategoriesService.GetById(ProductDTO.Category),
        Price = ProductDTO.Price,
        Stock = ProductDTO.Stock,
        Status = ProductDTO.Status
      };
    }
  }





}
