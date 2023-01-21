using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Services.CustomerService.cs {
  public interface ICustomerService {
    Task<DbResponse> Create(CustomerObject Customer);
    
    Task<DbResponse> Edit(CustomerObject Customer);

    Task<CustomerObject> GetById(String Id);
  }
}
