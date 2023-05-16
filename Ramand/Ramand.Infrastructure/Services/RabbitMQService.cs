using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Ramand.Domain.Contracts;
using Ramand.Infrastructure.Common;
using System.Text;
using System.Text.Json;

namespace Ramand.Infrastructure.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly RabbitMQConfigurations _rabbitMQConfigurations;
        public RabbitMQService(IOptions<RabbitMQConfigurations> rabbitMQConfigurations)
        {
            _rabbitMQConfigurations = rabbitMQConfigurations.Value;
        }

        public void SendMessage<T>(T message)
        {
            ConnectionFactory factory = new ConnectionFactory();

            factory.HostName = _rabbitMQConfigurations.HostName;
            factory.VirtualHost = _rabbitMQConfigurations.VirtualHost;
            factory.Port = _rabbitMQConfigurations.Port;
            factory.UserName = _rabbitMQConfigurations.UserName;
            factory.Password = _rabbitMQConfigurations.Password;

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var serializeMessage = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(serializeMessage);

            channel.QueueDeclare(queue: "UserQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.BasicPublish(exchange: "", routingKey: "UserQueue", basicProperties: null, body: body);
        }
    }
}
