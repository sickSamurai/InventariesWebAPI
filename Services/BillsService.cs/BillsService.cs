using InventariesWebAPI.Database;
using InventariesWebAPI.Domain.Responses;
using InventariesWebAPI.Domain.Entities;
using InventariesWebAPI.Services.TransactionsService;
using InventariesWebAPI.Domain.Objects;
using Microsoft.EntityFrameworkCore;
using InventariesWebAPI.Services.CustomerService.cs;

namespace InventariesWebAPI.Services.BillsService.cs {
  public class BillsService : IBillsService {

    private InventariesDbContext DbContext;
    private ITransactionsService TransactionsService;
    private ICustomerService CustomerService;

    public BillsService(InventariesDbContext context, ITransactionsService transactionsService, ICustomerService customerService) {
      DbContext = context;
      TransactionsService = transactionsService;
      CustomerService = customerService;
    }

    public async Task<TransactionResults[]> Create(BillToSaveObject Bill) {
      try {
        var TransactionsResults = await ValidateTransactions(Bill.Transactions);

        foreach(var Result in TransactionsResults)
          if(!Result.ProductAvailable) return TransactionsResults;

        var BillDTO = new Bill {
          Observations = Bill.Observations,
          Customer = Bill.Customer,
        };

        DbContext.Bills.Add(BillDTO);

        foreach(var Transaction in Bill.Transactions)
          await TransactionsService.Add(Transaction, BillDTO.Id);

        foreach(var Transaction in await TransactionsService.GetByBillingReference(BillDTO.Id))
          BillDTO.Total += Transaction.Subtotal;

        await DbContext.SaveChangesAsync();

        return TransactionsResults;
      } catch(Exception ex) {
        return Array.Empty<TransactionResults>();
      }
    }

    public Task<DbResponse> Edit(BillObject Bill) {
      throw new NotImplementedException();
    }

    public async Task<BillObject[]> GetByCreationDate(DateTime Date) {
      var BillsByDate = new List<BillObject>();
      var BillsDTO = await DbContext.Bills.Where(BillOnDb => BillOnDb.CreationDate == Date).ToArrayAsync();

      foreach(var Bill in BillsDTO)
        BillsByDate.Add(new BillObject {
          Id = Bill.Id,
          CreationDate = Bill.CreationDate,
          ExpirationDate = Bill.ExpirationDate,
          Observations = Bill.Observations,
          Transactions = await TransactionsService.GetByBillingReference(Bill.Id),
          Customer = await CustomerService.GetById(Bill.Customer),
          Total = Bill.Total
        });

      return BillsByDate.ToArray();

    }

    public async Task<TransactionResults[]> ValidateTransactions(TransactionToSaveObject[] Transactions) {
      try {
        var TransactionsResponses = new List<TransactionResults>();
        foreach(var Transaction in Transactions)
          TransactionsResponses.Add(await TransactionsService.ValidateTransaction(Transaction));
        return TransactionsResponses.ToArray();
      } catch(Exception ex) {
        return Array.Empty<TransactionResults>();
      }
    }
  }
}
