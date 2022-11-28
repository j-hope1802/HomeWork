using System.Data;
using Domain.Dtos;
using Npgsql;
using Dapper;
namespace Infrastructure.ProductService;
public class ProductService
{
    
    private string _connectionString = "Server=127.0.0.1;Port=5432; Database=Products;User Id=postgres;Password=11042004;";

    public List<Products> GetInfoProduct()
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = "Select * from Products";
            
            return conn.Query<Products>(sql).ToList();
        }
    }
       public int InsertProduct(Products  products)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql =
                    $"insert into products (ProductName, Company, ProductCount, Price) VALUES " +
                    $"('{products.ProductName}', " +
                    $"'{products.Company}', " +
                    $"'{products.ProductCount}', " +
                    $"'{products.Price}')";
                var result = conn.Execute(sql);

                return result;
            }
        }

         public int UpdateProduct(Products products)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = 
                    $"UPDATE products SET " +
                    $"productname = '{products.ProductName}', " +
                    $"company = '{products.Company}', " +
                    $"productcount = '{products.ProductCount}', " +
                    $"price = '{products.Price}'" +
                    $"WHERE Id = {products.Id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

          public int DeleteProduct(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"DELETE FROM Products WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

}