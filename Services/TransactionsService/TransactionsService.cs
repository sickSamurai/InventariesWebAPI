using InventariesWebAPI.Database;
using InventariesWebAPI.Domain.Responses;
using InventariesWebAPI.Domain.Entities;
using InventariesWebAPI.Domain.Objects;
using InventariesWebAPI.Services.ProductsService;
using Microsoft.EntityFrameworkCore;

namespace InventariesWebAPI.Services.TransactionsService {
  public class TransactionsService : ITransactionsService {
    private InventariesDbContext DbContext;
    private IProductsService ProductsService;

    public TransactionsService(InventariesDbContext dbContext, IProductsService productsService) {
      DbContext = dbContext;
      ProductsService = productsService;
    }

    public async Task<DbResponse> Add(TransactionToSaveObject Transaction, String BillId) {
      try {
        var ProductToSell = await ProductsService.GetById(Transaction.Product);
        ProductToSell.Stock -= Transaction.Units;
        await ProductsService.Edit(ProductToSell);
        var UnitPrice = GetUnitPrice(ProductToSell, Transaction.Discount);
        DbContext.Transactions.Add(new Transaction {
          Bill = BillId,
          Product = Transaction.Product,
          Units = Transaction.Units,
          Discount = Transaction.Discount,
          UnitPrice = UnitPrice,
          Subtotal = UnitPrice * Transaction.Units,
        });
        return new DbResponse { OperationSuccessful = await DbContext.SaveChangesAsync() != 0 };
      } catch(Exception ex) {
        return new DbResponse { OperationSuccessful = false };
      }
    }

    public decimal GetUnitPrice(ProductObject Product, decimal? Discount) {      
      if(Discount == null || Discount == 0) return Product.Price;
      else return (decimal) (Product.Price - Product.Price * Discount);
    }

    public async Task<TransactionObject[]> GetByBillingReference(string BillingReference) {
      List<TransactionObject> TransactionObjects = new();
      var TransactionsDTO = await DbContext.Transactions.Where(Transaction => Transaction.Bill == BillingReference).ToArrayAsync();

      foreach(var Transaction in TransactionsDTO) {
        TransactionObjects.Add(new TransactionObject {
          Id = Transaction.Id,
          Units = Transaction.Units,
          Discount = Transaction.Discount,
          UnitPrice = Transaction.UnitPrice,
          Product = await ProductsService.GetById(Transaction.Product),
          Subtotal = Transaction.Subtotal
        });
      }

      return TransactionObjects.ToArray();
    }

    public async Task<TransactionResults> ValidateTransaction(TransactionToSaveObject Transaction) {
      var ProductDTO = await ProductsService.GetById(Transaction.Product);
      return new TransactionResults {
        ProductName = ProductDTO.Name,
        ProductAvailable = ProductDTO.Stock >= Transaction.Units
      };
    }
  }
}
