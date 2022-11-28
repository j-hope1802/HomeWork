using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.OrderService
{
    public class OrderService
    {
        private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Products;User Id=postgres;Password=11042004;";

        public List<Orders> GetOrder()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Orders";

                return conn.Query<Orders>(sql).ToList();
            }
        }

        public int InsertOrder(Orders orders)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql =
                    $"insert into Orders (ProductId,CustomerId,CreatedAt,ProductCount,Price) VALUES " +
                    $"('{orders.ProductId}', " +
                      $"('{orders.CustomerId}', " +
                        $"('{orders.CreatedAt}', " +
                          $"('{orders.ProductCount}', " +
                            $"('{orders.Price}', ";
                var result = conn.Execute(sql);

                return result;
            }
        }

        public int UpdateOrder(Orders orders)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql =
                    $"Ordersname = '{orders.Id}', " +
                    $"Company = '{orders.CustomerId}', " +
                    $"Orderscount = '{orders.ProductCount}', " +
                    $"Price = '{orders.Price}'" +
                    $"WHERE Id = {orders.ProductId}";

                var result = conn.Execute(sql);

                return result;
            }
        }

        public int DeleteOrder(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"DELETE FROM Orders WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

    }
}