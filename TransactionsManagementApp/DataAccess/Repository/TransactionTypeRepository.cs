using Dapper;
using Microsoft.Data.SqlClient;
using TransactionsManagementApp.DataAccess.Entities;
using TransactionsManagementApp.DataAccess.Interface;
using TransactionsManagementApp.DataAccess.Querys;

namespace TransactionsManagementApp.DataAccess.Repository
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly IConfiguration configuration;

        public TransactionTypeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(TransactionType entity)
        {
            var query = Statement.AddTransactionType();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = Statement.DeleteTransactionType();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, new { TransactionTypeId = id });
                return result;
            }
        }

        public async Task<IEnumerable<TransactionType>> GetAllAsync()
        {
            var query = Statement.GetAllTransactionTypes();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<TransactionType>(query);
                return result.ToList();
            }
        }

        public async Task<TransactionType> GetByIdAsync(int id)
        {
            var query = Statement.GetTransactionTypeById();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<TransactionType>(query, new { TransactionTypeId = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(TransactionType entity)
        {
            var query = Statement.UpdateTransactionType();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
