using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            routes.Add("firstapi", "http://localhost:52239");
            routes.Add("secondapi", "http://localhost:42345");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.Run(async (context) =>
            {
                await CallApi(context);

            });
        }
        private static async Task CallApi(HttpContext context)
        {
            var apiKey = context.Request.Path.Value.Split("/")[1];
            var apiAddress = routes[apiKey];
            var client = new RestClient(apiAddress);

            string resource = apiAddress + "/" + context.Request.Path.Value.Split("/")[2];
            var request = new RestRequest(resource, DataFormat.Json);

            var response = client.Get(request);

            await context.Response.WriteAsync(response.Content);
        }

        static Dictionary<string, string> routes = new Dictionary<string, string>();
    }


}
