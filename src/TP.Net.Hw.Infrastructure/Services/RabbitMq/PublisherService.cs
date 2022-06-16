using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using TP.Net.Hw.Application.Interfaces.Services.RabbitMq;
using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.Infrastructure.Services.RabbitMq
{
    public class PublisherService : IPublisherService
    {
        private readonly IRabbitMqConnection _rabbitMqConnection;

        public PublisherService(IRabbitMqConnection rabbitMqConnection) => _rabbitMqConnection = rabbitMqConnection;

        public void Publish(User user, string queueName, string routingKey)
        {
            //creating the RabbitMQ connection 
            using var connection = _rabbitMqConnection.GetRabbitMqConnection();
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