using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.Application.Interfaces.Services
{
    public interface IPublisherService
    {
        void Publish(User user, string queueName, string routingKey);
    }
}
