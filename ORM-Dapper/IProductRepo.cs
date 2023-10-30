using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();

        public void CreateProduct(string product);

        public Product GetProduct(int productID);

        public void UpdateProduct(Product product);

        public void DeleteProduct(int productID);
    }
}
