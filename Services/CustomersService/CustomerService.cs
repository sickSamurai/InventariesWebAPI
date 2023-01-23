using InventariesWebAPI.Database;
using InventariesWebAPI.Domain.Entities;
using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Services.CustomerService.cs {
  public class CustomerService : ICustomerService {

    private InventariesDbContext DbContext;

    public CustomerService(InventariesDbContext dbContext) {
      DbContext = dbContext;
    }

    public async Task<DbResponse> Create(CustomerObject Customer) {
      try {
        DbContext.Customers.Add(new Customer {
          Id = Customer.Id,
          Name = Customer.Name,          
          Phone = Customer.Phone,
          Email = Customer.Email,
          Address = Customer.Address,
        });
        return new DbResponse { OperationSuccessful = await DbContext.SaveChangesAsync() != 0 };
      } catch(Exception ex) {
        return new DbResponse { OperationSuccessful = false };
      }
    }

    public async Task<DbResponse> Edit(CustomerObject Customer) {
      try {
        DbContext.Customers.Update(new Customer {
          Id = Customer.Id,
          Name = Customer.Name,
          Address = Customer.Address,
          Phone = Customer.Phone,
          Email = Customer.Email,          
        });
        return new DbResponse { OperationSuccessful = await DbContext.SaveChangesAsync() != 0 };
      } catch(Exception ex) {
        return new DbResponse { OperationSuccessful = false };
      }
    }

    public async Task<CustomerObject> GetById(string Id) {
      var DTO = await DbContext.Customers.FindAsync(Id);
      if(DTO == null) throw new Exception("Can't found a Customer with that Id");
      return new CustomerObject { Id = DTO.Id, Name = DTO.Name, Address = DTO.Address, Email = DTO.Email, Phone = DTO.Email };
    }


  }
}
