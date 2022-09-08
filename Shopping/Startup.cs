using Contract;
using CronQuery.Mvc.DependencyInjection;
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
using Shopping.Integration;
using Shopping.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping
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
          //  services.AddDbContext<ShoppingDbContext>(opt=>opt.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddDbContext<ShoppingDbContext>(opt=>opt.UseInMemoryDatabase("ShoppingDb"));
            services.AddControllers();
            services.AddMassTransit(x =>
            {
                //// TODO: Auto Register Consumers
                x.AddConsumer<StockAdjusmentConfirmedEventHandler>();
                x.AddConsumer<StockAdjusmentRejectedEventHandler>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint(nameof(StockAdjusmentConfirmedEvent), e =>
                    {
                        e.ConfigureConsumer<StockAdjusmentConfirmedEventHandler>(context);
                    });

                    cfg.ReceiveEndpoint(nameof(StockAdjusmentRejectedEvent), e =>
                    {
                        e.ConfigureConsumer<StockAdjusmentRejectedEventHandler>(context);
                    });
                });
            });
            services.AddMassTransitHostedService();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopping", Version = "v1" });
            });
            services.AddScoped<IOrderService, OrderService>();

            services.AddCronQuery(Configuration.GetSection("CronQuery"));
            
            services.AddScoped<OutboxPublisher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
        {
            //prepare database
            serviceProvider.GetService<ShoppingDbContext>().Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping v1"));
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
