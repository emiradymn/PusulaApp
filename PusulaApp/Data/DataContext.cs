using Microsoft.EntityFrameworkCore;
using PusulaApp.Models;

namespace PusulaApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Sale> Sales => Set<Sale>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, ProductName = "Laptop", Price = 1500.00M },
                new Product { ProductID = 2, ProductName = "Mouse", Price = 25.00M },
                new Product { ProductID = 3, ProductName = "Keyboard", Price = 45.00M }
            );

            modelBuilder.Entity<Sale>().HasData(
                new Sale { SaleID = 1, ProductID = 1, Quantity = 2, SaleDate = new DateTime(2024, 1, 10) },
                new Sale { SaleID = 2, ProductID = 2, Quantity = 5, SaleDate = new DateTime(2024, 1, 15) },
                new Sale { SaleID = 3, ProductID = 1, Quantity = 1, SaleDate = new DateTime(2024, 2, 20) },
                new Sale { SaleID = 4, ProductID = 3, Quantity = 3, SaleDate = new DateTime(2024, 3, 5) },
                new Sale { SaleID = 5, ProductID = 2, Quantity = 7, SaleDate = new DateTime(2024, 3, 25) },
                new Sale { SaleID = 6, ProductID = 3, Quantity = 2, SaleDate = new DateTime(2024, 4, 12) }
            );
        }
    }
}