using IRepository_Generic_Repository_Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

class Program
{
    static void Main()
    {
        string connectionString = ("Server=DESKTOP-JI1JKUA\\SQLEXPRESS;Database=Products;Trusted_Connection=true");
        var productRepository = new ProductRepository(connectionString);

        var allProducts = productRepository.GetAllProducts();
        Console.WriteLine("Tüm ürünler:");
        foreach (var product in allProducts)
        {
            Console.WriteLine($"Ürün id : {product.ProductId}, Ürün ismi : {product.ProductName}, Fiyat: {product.Price}");
        }
        var specificProduct = productRepository.GetProductById(1);
        Console.WriteLine("Seçilen ürün :");
        Console.WriteLine($"Ürün id : {specificProduct.ProductId},  Ürün ismi: {specificProduct.ProductName}, Fiyat : {specificProduct.Price}");

        var newProduct = new Product { ProductName = "New Product", Price = 19.99m };
        productRepository.AddProduct(newProduct);
        Console.WriteLine("Ürün başarıyla eklendi.");

        Console.ReadLine();
    }
}
