using RabbitMQ.Client;
using TP.Net.Hw.Application.Interfaces.Services.RabbitMq;

namespace TP.Net.Hw.Infrastructure.Services.RabbitMq
{
    public class RabbitMqConnection : IRabbitMqConnection
    {
        public IConnection GetRabbitMqConnection()
        {
            return new ConnectionFactory()
            {
                HostName = "localhost",
                VirtualHost = "/",
                Port = 5672,
                UserName = "guest",
                Password = "guest"

            }.CreateConnection();
        }
    }
}
