using InventariesWebAPI.Domain.Objects;
using InventariesWebAPI.Domain.Responses;

namespace InventariesWebAPI.Services.TransactionsService {
  public interface ITransactionsService {
    Task<DbResponse> Add(TransactionToSaveObject Transaction, String BillId);

    Task<TransactionResults> ValidateTransaction(TransactionToSaveObject Transaction);


    Task<TransactionObject[]> GetByBillingReference(string BillingReference);
  }
}
