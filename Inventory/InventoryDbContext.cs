using Inventory.Model;
using Microsoft.EntityFrameworkCore;

namespace Inventory
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


 
            base.OnModelCreating(modelBuilder);
        }
    }
}
