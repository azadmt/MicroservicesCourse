using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Service
{
    public class InventoryDbContext :DbContext
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
            var stock = new Stock { ProductId = 1, Quantity= 100};
            modelBuilder.Entity<Stock>().HasData(stock);
        }
    }
}
