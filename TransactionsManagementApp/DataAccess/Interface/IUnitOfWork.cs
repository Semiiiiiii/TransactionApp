namespace TransactionsManagementApp.DataAccess.Interface
{
    public interface IUnitOfWork
    {
        IStatusRepository Status { get; }
        ITransactionTypeRepository TransactionType { get; }
        ITransactionsRepository Transactions { get; }

    }
}
