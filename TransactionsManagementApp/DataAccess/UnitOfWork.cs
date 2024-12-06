using TransactionsManagementApp.DataAccess.Interface;

namespace TransactionsManagementApp.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public IStatusRepository Status { get; }

        public ITransactionTypeRepository TransactionType { get; }

        public ITransactionsRepository Transactions { get; }
    }
}
