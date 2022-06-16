using RabbitMQ.Client;

namespace TP.Net.Hw.Application.Interfaces.Services.RabbitMq
{
    public interface IRabbitMqConnection
    {
        IConnection GetRabbitMqConnection();
    }
}
