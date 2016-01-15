using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class productContext:DbContext
    {
        public productContext(string connStr) 
        { 
            Database.SetInitializer(new CreateDatabaseIfNotExists<productContext>());
            Database.Connection.ConnectionString = connStr; 
        }
        public DbSet<Product> products { get; set; }
    }
}