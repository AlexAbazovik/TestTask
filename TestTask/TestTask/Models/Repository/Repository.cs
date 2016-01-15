using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Controllers;

namespace TestTask.Models.Repository
{
    public class Repository:IRepository
    {
        productContext context;
        public Repository(string connStr) { context = new productContext(connStr); }
        public IEnumerable<Product> Products
        {
            get { return context.products.ToList<Product>(); }
        }

        public Product AddProduct()
        {
            Product product = new Product();
            return product;
        }

        public void saveProduct(Product p)
        {
            context.products.Add(p);
            context.SaveChanges();
            return;
        }

        public void deleteProduct( int id)
        {
            context.products.Remove(context.products.Where(p => p.ID == id).Select(p => p).First());
            context.SaveChanges();
            return;
        }
    }
}