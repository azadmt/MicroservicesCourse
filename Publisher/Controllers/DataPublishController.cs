using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataPublishController : ControllerBase
    {
 

        private readonly ILogger<DataPublishController> _logger;

        public DataPublishController(ILogger<DataPublishController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Publish(int code,string content)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            const string ExchangeName= "";
            const string QueueName = "example1_custommessage_queue";
            using var connection = connectionFactory.CreateConnection();

            using var channel = connection.CreateModel();

            var queue = channel.QueueDeclare(
                queue: QueueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: ImmutableDictionary<string, object>.Empty);


                var customMessage =new CustomMessage {Content=content,Code=code };

                channel.BasicPublish(
                    exchange: ExchangeName,
                    routingKey: QueueName,
                    body: customMessage.ToBytes()
                );



            return Ok();
            
        }
    }
}
