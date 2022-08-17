using Contract;
using DeliveryManagement.Integration;
using DeliveryManagement.Service;
using MassTransit;
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

namespace DeliveryManagement
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
            services.AddDbContext<DeliveryManagementDbContext>(opt => opt.UseInMemoryDatabase("DeliveryManagementDb"));
            services.AddControllers();

            services.AddMassTransit(x =>
            {
                //// TODO: Auto Register Consumers
                x.AddConsumer<OrderPlacedEventHandler>();
                // x.UsingRabbitMq();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint(nameof(OrderPlacedEvent), e =>
                    {
                        e.ConfigureConsumer<OrderPlacedEventHandler>(context);
                    });
                });
            });
            services.AddMassTransitHostedService();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeliveryManagement", Version = "v1" });
            });
            services.AddScoped<IDeliveryService, DeliveryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
        {
            serviceProvider.GetService<DeliveryManagementDbContext>().Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeliveryManagement v1"));
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
