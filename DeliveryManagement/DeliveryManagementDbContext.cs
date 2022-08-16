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
    }
}
