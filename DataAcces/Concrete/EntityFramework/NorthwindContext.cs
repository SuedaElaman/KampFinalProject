using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Context: Db tabloları ile proje classlarını bağlama
    public class NorthwindContext : DbContext
    {
        //Bu bölümde contex hangi veri tabanına bağlanacağını buldu
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");

        }
        public DbSet<Product> Products { get; set; } // benim product nesnemi veritabanındaki product ile bağla  //benim hangi classım hangi tabloya karşılık geliyor.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
