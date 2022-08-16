﻿using Newtonsoft.Json;
using Shopping.Model;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Shopping.Service
{
    public class DeliveryService : IDeliveryService
    {
        private readonly HttpClient httpClient;

        public DeliveryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public void ScheduleDelivery(long id, string address)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new ScheduleDeliveryDto { Address = address, OrderId = id }), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("https://localhost:44309/Delivery", content).Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception("ScheduleDelivery Exception");
        }
    }

    public class ScheduleDeliveryDto
    {
        public long OrderId { get; set; }
        public string Address { get; set; }
    }

}


