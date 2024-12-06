namespace TransactionsManagementApp.DataAccess.Querys
{
    public class Statement
    {
        #region StatusType Queries
        public static string GetStatusById()
        {
            return "SELECT * FROM Status WHERE StatusId = @StatusId";
        }
        public static string AddStatus()
        {
            return "INSERT INTO Status (StatusId,StatusName) VALUES  (@StatusId,@StatusName)";
        }
        public static string DeleteStatus()
        {
            return "DELETE  FROM Status WHERE StatusId=@StatusId";
        }

        public static string GetAllStatus()
        {
            return "SELECT * FROM Status ";
        }

        public static string UpdateStatus()
        {
            return "UPDATE Status SET  StatusName = @StatusName WHERE StatusId = @StatusId  ";
        }
        #endregion

        #region TransactionType Queries

        public static string GetAllTransactionTypes()
        {
            return "SELECT * FROM TransactionType";
        }

        public static string GetTransactionTypeById()
        {
            return "SELECT * FROM TransactionType WHERE TransactionTypeId = @TransactionTypeId";
        }

        public static string AddTransactionType()
        {
            return "INSERT INTO TransactionType (TypeName) VALUES (@TypeName)";
        }

        public static string UpdateTransactionType()
        {
            return "UPDATE TransactionType SET TypeName = @TypeName WHERE TransactionTypeId = @TransactionTypeId";
        }

        public static string DeleteTransactionType()
        {
            return "DELETE FROM TransactionType WHERE TransactionTypeId = @TransactionTypeId";
        }
        #endregion

        #region Transactions Queries

        public static string GetTransactionById()
        {
            return "SELECT * FROM Transactions WHERE TransactionId = @TransactionId";
        }

        public static string AddTransaction()
        {
            return "INSERT INTO Transactions (Amount, TransactionTypeId, TransactionDate, Description, StatusId, CustomerFullName, CustomerPhone, CustomerAddress, CustomerEmail) " +
                   "VALUES (@Amount, @TransactionTypeId, @TransactionDate, @Description, @StatusId, @CustomerFullName, @CustomerPhone, @CustomerAddress, @CustomerEmail)";
        }

        public static string DeleteTransaction()
        {
            return "DELETE FROM Transactions WHERE TransactionId = @TransactionId";
        }

        public static string GetAllTransactions()
        {
            return "SELECT * FROM Transactions";
        }

        public static string UpdateTransaction()
        {
            return "UPDATE Transactions SET " +
                   "Amount = @Amount, " +
                   "TransactionTypeId = @TransactionTypeId, " +
                   "TransactionDate = @TransactionDate, " +
                   "Description = @Description, " +
                   "StatusId = @StatusId, " +
                   "CustomerFullName = @CustomerFullName, " +
                   "CustomerPhone = @CustomerPhone, " +
                   "CustomerAddress = @CustomerAddress, " +
                   "CustomerEmail = @CustomerEmail " +
                   "WHERE TransactionId = @TransactionId";
        }
        //note
        //if the CustomerName is empty it shows the result for the scenario of totalTransactions that are in the table
        //if it comes with the cumstomername it shows the  totalTransactions onky for this user
        public static string GetTransactionSummary()
        {
            return @"
        SELECT  
            COUNT(*) AS TotalTransactions,
            SUM(CASE WHEN t.TransactionTypeId = 1 THEN t.Amount ELSE 0 END) AS TotalCredits,
            SUM(CASE WHEN t.TransactionTypeId = 2 THEN t.Amount ELSE 0 END) AS TotalDebits,  
            SUM(CASE WHEN t.TransactionTypeId = 1 THEN t.Amount ELSE -t.Amount END) AS NetBalance 
        FROM Transactions t
        JOIN TransactionTypes tt ON t.TransactionTypeId = tt.TransactionTypeId
        WHERE (@CustomerName IS NULL OR t.CustomerFullName LIKE '%' + @CustomerName + '%')";
        }
        #endregion

        

    }
}
