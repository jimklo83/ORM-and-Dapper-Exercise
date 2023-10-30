using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class ProductRepo : IProductRepo
    {
        private readonly IDbConnection _connection;

        public ProductRepo(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void CreateProduct(string product)
        {
            _connection.Execute("INSERT INTO products (Name) VALUES (@product);",
                new { product });
        }

        public Product GetProduct(int productID)
        {
            return _connection.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @productID;",
                new { productID });
        }

        public void UpdateProduct(Product product)
        {
            _connection.Execute("UPDATE products" +
                                " SET Name = @name, " +
                                " Price = @price, " +
                                " CategoryID = @categoryID," +
                                " OnSale = @onSale, " +
                                " StockLevel = @stockLevel" +
                                " WHERE ProductID = @productID;",
                                new 
                                {
                                productID = product.ProductID,
                                name = product.Name, 
                                price = product.Price, 
                                categoryID = product.CategoryID, 
                                onSale = product.OnSale, 
                                stockLevel = product.StockLevel 
                                });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
                new { productID });
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID });
            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
                new { productID });
        }
    }
}
