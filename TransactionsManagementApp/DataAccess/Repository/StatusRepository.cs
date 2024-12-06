using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.Common;
using TransactionsManagementApp.DataAccess.Entities;
using TransactionsManagementApp.DataAccess.Interface;
using TransactionsManagementApp.DataAccess.Querys;
using TransactionsManagementApp.Model;

namespace TransactionsManagementApp.DataAccess.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly IConfiguration configuration;

        public StatusRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Status entity)
        {
            var query = Statement.AddStatus();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = Statement.DeleteStatus();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, new { StatusId = id });
                return result;
            }
        }

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            var query = Statement.GetAllStatus();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Status>(query);
                return result.ToList();
            }
        }

        public async  Task<Status> GetByIdAsync(int id)
        {
            var query = Statement.GetStatusById();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Status>(query, new { StatusId = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Status entity)
        {
            var query = Statement.UpdateStatus();
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
