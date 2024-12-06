namespace TransactionsManagementApp.Model
{
    public class TransactionSummary
    {
        public int TotalTransactions { get; set; }
        public decimal TotalCredits { get; set; }
        public decimal TotalDebits { get; set; }
        public decimal NetBalance { get; set; }
    }

}
