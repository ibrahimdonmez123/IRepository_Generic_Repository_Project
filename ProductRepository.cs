
using IRepository_Generic_Repository_Project;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

public class ProductRepository
{
    private readonly string _connectionString;

    public ProductRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        using (IDbConnection dbConnection = new SqlConnection(_connectionString))
        {
            dbConnection.Open();
            return dbConnection.Query<Product>("SELECT * FROM Products");
        }
    }

    public Product GetProductById(int productId)
    {
        using (IDbConnection dbConnection = new SqlConnection(_connectionString))
        {
            dbConnection.Open();
            return dbConnection.QueryFirstOrDefault<Product>("SELECT * FROM Products WHERE ProductId = @ProductId", new { ProductId = productId });
        }
    }

    public void AddProduct(Product product)
    {
        using (IDbConnection dbConnection = new SqlConnection(_connectionString))
        {
            dbConnection.Open();
            dbConnection.Execute("INSERT INTO Products (ProductName, Price) VALUES (@ProductName, @Price)", product);
        }
    }
}
