using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;

namespace Shopping_ApiGateway.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public ControllerBase(RestClient client)
        {
            RestClient = client;
        }

        protected RestClient RestClient { get; }

        protected string GetServiceEndponit(string serviceName)
        {
            //TODO : Read  ServiceDiscovery Address from config
            var request = new RestRequest(new Uri($"http://localhost:18224/ServiceManagement?serviceName={serviceName}"), Method.Get);
            var response = RestClient.Get<string>(request);
            return response;
        }
    }
}