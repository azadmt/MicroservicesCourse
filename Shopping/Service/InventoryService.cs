using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service
{
    public class InventoryService : IInventoryService
    {
        private readonly HttpClient httpClient;

        public InventoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task AdjustStockQuantity(long productId, int quantity)
        {
            var content = new StringContent(JsonConvert.
                SerializeObject(new AdjustStockQuantity { ProductId = productId, Quantity = quantity}), 
                Encoding.UTF8, "application/json");
            //get url from config
            var response = await httpClient.PostAsync("https://localhost:52444/AdjustStockQuantity", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception("ScheduleDelivery Exception");
        }
    }

    public class AdjustStockQuantity
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }

}


