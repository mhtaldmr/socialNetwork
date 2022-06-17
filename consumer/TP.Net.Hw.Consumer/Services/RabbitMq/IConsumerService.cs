namespace TP.Net.Hw.Consumer.Services.RabbitMq
{
    public interface IConsumerService
    {
        void Consume(string queueName, bool IsAcknowledgeAuto);
    }
}
