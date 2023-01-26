using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Diagnostics.Metrics;
using System.Text;
using TaskTracker.Events.Integration;
using TaskTracker.Interfaces;

namespace TaskTracker.Services
{
    public class RabbitMQService : IIntegrationService
    {
        private const string _queueName = "projects_tasks";
        private readonly RabbitMqConfiguration _configuration;
        public RabbitMQService(IOptions<RabbitMqConfiguration> options)
        {
            _configuration = options.Value;
        }
        public void Publish(IntegrationEvent integrationEvent)
        {
            var factory = new ConnectionFactory()
            {
                UserName = _configuration.Username,
                Port= _configuration.Port,
                Password = _configuration.Password,
                HostName = _configuration.HostName
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(integrationEvent);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                    routingKey: _queueName,
                                    basicProperties: null,
                                    body: body);
            }
        }
    }
}
