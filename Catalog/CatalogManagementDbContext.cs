using Catalog.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalog
{
    public class CatalogManagementDbContext : DbContext
    {
        public CatalogManagementDbContext(DbContextOptions<CatalogManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var productGroup1 = new ProductGroup { Id = 1, Name = "LapTop" };
            var productGroup2 = new ProductGroup { Id = 2, Name = "Mobile" };
            var product1 = new Product { Id = 1, Name = "Asuse K55", Price = 15000000, ProductGroupId = productGroup1.Id };
            var product2 = new Product { Id = 2, Name = "HP S450", Price = 10000000, ProductGroupId = productGroup1.Id };
            var product3 = new Product { Id = 3, Name = "Samsung a70", Price = 18000000, ProductGroupId = productGroup2.Id };


            modelBuilder.Entity<ProductGroup>().HasData(productGroup1);
            modelBuilder.Entity<ProductGroup>().HasData(productGroup2);

            modelBuilder.Entity<Product>().HasData(product1);
            modelBuilder.Entity<Product>().HasData(product2);
            modelBuilder.Entity<Product>().HasData(product3);
            base.OnModelCreating(modelBuilder);
        }
    }
}
