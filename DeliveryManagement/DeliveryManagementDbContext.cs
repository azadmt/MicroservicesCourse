using DeliveryManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryManagement
{
    public class DeliveryManagementDbContext : DbContext
    {
        public DeliveryManagementDbContext(DbContextOptions<DeliveryManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Courier> Couriers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var courier = new Courier { Id = 1, IsAvailable = true };
            modelBuilder.Entity<Courier>().HasData(courier);
        }
    }
}
