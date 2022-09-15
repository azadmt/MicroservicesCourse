using Contract;
using InventoryManagement.Integration;
using InventoryManagement.Service;
using MassTransit;
using MassTransit.Context;
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

namespace InventoryManagement
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

            services.AddDbContext<InventoryDbContext>(opt => opt.UseInMemoryDatabase("InventoryManagementDb"));
            services.AddControllers();
            MessageCorrelation.UseCorrelationId<OrderCreatedEvent>(x => new Guid());
            services.AddMassTransit(x =>
            {                
                //// TODO: Auto Register Consumers
                x.AddConsumer<OrderCreatedEventHandler>();
                // x.UsingRabbitMq();
                x.UsingRabbitMq((context, cfg) =>
                {
                 
                    cfg.ReceiveEndpoint(nameof(OrderCreatedEvent), e =>
                    {
                        e.ConfigureConsumer<OrderCreatedEventHandler>(context);
                    });
                });
            });
            services.AddMassTransitHostedService();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeliveryManagement", Version = "v1" });
            });
            services.AddScoped<IStockService, StockService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventoryManagement v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
