using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.CustomerService
{
    public class CustomersService
    {
        private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Products;User Id=postgres;Password=11042004;";

        public List<Customer> GetCustomers()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Customers";

                return conn.Query<Customer>(sql).ToList();
            }
        }

        public int InsertCustomer(Customer customer)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql =
                    $"insert into Products(FirstName, id) VALUES " +
                    $"('{customer.FirstName}', " ;
                var result = conn.Execute(sql);

                return result;
            }
        }

        public int UpdateCustomer(Customer customer)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = 
                    $"UPDATE Products SET " +
                    $"name= '{customer.FirstName}', " +
                  
                    $"WHERE id = {customer.Id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

        public int DeleteCustomer(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"DELETE FROM students WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

    }
}