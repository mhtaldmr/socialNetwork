using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using TP.Net.Hw.Application.Interfaces.Services;
using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.Infrastructure.Services
{
    public class PublisherService : IPublisherService
    {
        public void Publish(User user, string queueName, string routingKey)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                VirtualHost = "/",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            //creating the RabbitMQ connection 
            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            //Creating exchanges and queues
            channel.ExchangeDeclare(exchange: "direct.test", type: "direct", durable: false, autoDelete: false);
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: true);

            //Binding the exchanges and queues created into eachother with routingkey
            channel.QueueBind(queue: queueName, exchange: "direct.test", routingKey: routingKey);

            //User is an object, for that changing that into Bytes..
            var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(user));

            //At last, we are publishing the message.
            channel.BasicPublish(exchange: "direct.test", routingKey: routingKey, basicProperties: null, body: messageBody);
        }
    }
}