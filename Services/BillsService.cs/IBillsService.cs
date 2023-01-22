using InventariesWebAPI.Domain.Objects;
using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Services.BillsService.cs {
  public interface IBillsService {
    Task<TransactionResults[]> Create(BillToSaveObject Bill);
    
    Task<DbResponse> Edit(BillObject Bill);

    Task<BillObject[]> GetByCreationDate(DateTime Date);

  }
}
