using Dapper;
using Microsoft.Data.SqlClient;
using TransactionsManagementApp.DataAccess.Entities;
using TransactionsManagementApp.DataAccess.Interface;
using TransactionsManagementApp.DataAccess.Querys;
using TransactionsManagementApp.Model;
using static Dapper.SqlMapper;

namespace TransactionsManagementApp.DataAccess.Repository
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly IConfiguration configuration;

        public TransactionsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Transactions entity)
        {
            var query = Statement.AddTransaction();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = Statement.DeleteTransaction();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, new { TransactionsId = id });
                return result;
            }
        }

        public async Task<IEnumerable<Transactions>> GetAllAsync()
        {
            var query = Statement.GetAllTransactions();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Transactions>(query);
                return result.ToList();
            }
        }

        public async Task<Transactions> GetByIdAsync(int id)
        {
            var query = Statement.GetTransactionById();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Transactions>(query, new { TransactionsId = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Transactions entity)
        {
            var query = Statement.UpdateTransaction();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }
        public async Task<TransactionSummary> GetTransactionSummaryAsync(string? customerName = null)
        {
            var query = Statement.GetTransactionSummary();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var result = await connection.QuerySingleOrDefaultAsync<TransactionSummary>(query, new { CustomerName = customerName });
                return result;
            }
        }

       
    }
}
