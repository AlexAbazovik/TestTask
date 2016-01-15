using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models.Repository
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        Product AddProduct();
        void saveProduct(Product p);
        void deleteProduct(int productId);
    }
}