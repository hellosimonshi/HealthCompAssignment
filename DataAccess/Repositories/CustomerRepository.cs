using DataAccess.Interfaces;
using DataAccess.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration configuration;
        public CustomerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Customer entity)
        {
            entity.AddedOn = DateTime.Now;
            var sql = "Insert into Customers (Name,Description,AddedOn) VALUES (@Name,@Description,@AddedOn)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Customers WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }
        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            var sql = "SELECT * FROM Customers";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Customer>(sql);
                return result.ToList();
            }
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Customers WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Customer>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<int> UpdateAsync(Customer entity)
        {
            entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE Customers SET Name = @Name, Description = @Description, ModifiedOn = @ModifiedOn  WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        public int Update(Customer entity)
        {
            entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE Customers SET Name = @Name, Description = @Description, ModifiedOn = @ModifiedOn  WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
    }
}
