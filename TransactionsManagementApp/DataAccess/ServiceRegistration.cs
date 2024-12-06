using Microsoft.Data.SqlClient;
using System.Data;
using TransactionsManagementApp.DataAccess.Interface;
using TransactionsManagementApp.DataAccess.Repository;

namespace TransactionsManagementApp.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDbConnection>(c => new SqlConnection("DefaultConnection"));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<ITransactionTypeRepository, TransactionTypeRepository>();
            services.AddTransient<ITransactionsRepository, TransactionsRepository>();
           

        }
    }
}
