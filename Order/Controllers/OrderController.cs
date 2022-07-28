using Microsoft.AspNetCore.Mvc;
using OrderManagement.Contract;
using OrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Transactions;
using Common;
namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly OrderManagementDbContext orderManagementDbContext;

        public OrderController(IHttpClientFactory clientFactory, OrderManagementDbContext orderManagementDbContext)
        {
            this.clientFactory = clientFactory;
            this.orderManagementDbContext = orderManagementDbContext;
        }

        //https://www.c-sharpcorner.com/article/distributed-transactions-with-webapi-across-application-domains/
        [HttpGet]
        public IActionResult Index()
        {
            var result = orderManagementDbContext.Orders.ToList();
            return Ok(result);
        }

        [HttpPost("PlaceOrder")]
        
        public async Task<IActionResult> PlaceOrder(OrderDto order)
        {
            using (var trx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                orderManagementDbContext.Orders.Add(Order.CreateOrder(order));
                var inventoryUpdated = await UpdateInventory(order.OrderItems.First().ProductId, order.OrderItems.First().Unit);
                if (order.CustomerId != 1) throw new Exception("Customer is not valid!!!");
                if (inventoryUpdated)
                {
                    orderManagementDbContext.SaveChanges();
                }
                trx.Complete();
            }
            return Ok();
        }


        private async Task<bool> UpdateInventory(long productId,int count)
        {        
            using var client = clientFactory.CreateClient();
            using var request = new HttpRequestMessage(HttpMethod.Post,
                "http://localhost:22144/Stock/UpdateStock");
            request.AddTransactionPropagationToken();
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Content = JsonContent.Create(new { ProductId = productId, Count = count });
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();      
            return response.IsSuccessStatusCode;
        }
    }
}
