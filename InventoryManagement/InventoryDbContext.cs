using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
       
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var stock1 = new Stock { Id = 1, ProductId = 1, Quantity = 1000 };
            var stock2 = new Stock { Id = 2, ProductId = 2, Quantity = 10000 };
            var stock3 = new Stock { Id = 3, ProductId = 3, Quantity = 500 };

            modelBuilder.Entity<Stock>().HasData(stock1);
            modelBuilder.Entity<Stock>().HasData(stock2);
            modelBuilder.Entity<Stock>().HasData(stock3);
        }
    }
}
