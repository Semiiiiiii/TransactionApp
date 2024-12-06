using TransactionsManagementApp.DataAccess.Entities;
using TransactionsManagementApp.Model;

namespace TransactionsManagementApp.DataAccess.Interface
{
    public interface ITransactionsRepository : IGenericRepository<Transactions>
    {
        Task<TransactionSummary> GetTransactionSummaryAsync(string? customerName = null);
    }
}
