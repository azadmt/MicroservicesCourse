using Inventory.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InventoryDbContext>(opt => opt.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Inventory", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,InventoryDbContext inventoryDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            FillData(inventoryDbContext);
        }

        private void FillData(InventoryDbContext inventoryDbContext)
        {

            var stock1 = new Stock {/* Id = 1,*/ ProductId = 1, Quantity = 1000 };
            var stock2 = new Stock {/* Id = 2,*/ ProductId = 2, Quantity = 10000 };
            var stock3 = new Stock {/* Id = 3,*/ ProductId = 3, Quantity = 500 };
            if (inventoryDbContext.Stocks.Any()) return;
            inventoryDbContext.Stocks.Add(stock1);
            inventoryDbContext.Stocks.Add(stock2);
            inventoryDbContext.Stocks.Add(stock3);
            inventoryDbContext.SaveChanges();
        }
    }
}
