using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
//^^^^MUST HAVE USING DIRECTIVES^^^^

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            #region Department Section
            var depRepo = new DepartmentRepo(conn);

            depRepo.DeleteDepartment(6);
            depRepo.DeleteDepartment(7);
            var departments = depRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentID}; {department.Name}");
                Console.WriteLine();
            }

            #endregion

            #region Product Section

            var prodRepo = new ProductRepo(conn);
            var updateProduct = prodRepo.GetProduct(942);

            updateProduct.Name = "UPDATED!";
            updateProduct.Price = 1000;
            updateProduct.CategoryID = 1;
            updateProduct.OnSale = false;
            updateProduct.StockLevel = 1;

            prodRepo.UpdateProduct(updateProduct);

            prodRepo.DeleteProduct(942);

            var products = prodRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }

            #endregion
        }
    }
}