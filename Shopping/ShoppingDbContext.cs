using Microsoft.EntityFrameworkCore;
using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Shopping
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options)
        {

        }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var productGroup1 = new ProductGroup { Id = 1, Name = "LapTop" };
            var productGroup2 = new ProductGroup { Id = 2, Name = "Mobile" };
            var product1 = new Product { Id = 1, Name = "Asuse K55", Price = 15000000, ProductGroupId = productGroup1.Id, Quantity = 1000 };
            var product2 = new Product { Id = 2, Name = "HP S450", Price = 10000000, ProductGroupId = productGroup1.Id, Quantity = 10000 };
            var product3 = new Product { Id = 3, Name = "Samsung a70", Price = 18000000, ProductGroupId = productGroup2.Id, Quantity = 500 };
            var stock1 = new Stock { Id = 1, ProductId = product1.Id, Quantity = 1000 };
            var stock2 = new Stock { Id = 2, ProductId = product2.Id, Quantity = 10000 };
            var stock3 = new Stock { Id = 3, ProductId = product3.Id, Quantity = 500 };
            var customer = new Customer { Id = 1, Name = "Mohammad azad", Type = CustomerType.Gold };
            var courier = new Courier { Id = 1, IsAvailable = true };

            modelBuilder.Entity<ProductGroup>().HasData(productGroup1);
            modelBuilder.Entity<ProductGroup>().HasData(productGroup2);

            modelBuilder.Entity<Product>().HasData(product1);
            modelBuilder.Entity<Product>().HasData(product2);
            modelBuilder.Entity<Product>().HasData(product3);

            modelBuilder.Entity<Stock>().HasData(stock1);
            modelBuilder.Entity<Stock>().HasData(stock2);
            modelBuilder.Entity<Stock>().HasData(stock3);

            modelBuilder.Entity<Customer>().HasData(customer);
            modelBuilder.Entity<Courier>().HasData(courier);
        }
    }
}
