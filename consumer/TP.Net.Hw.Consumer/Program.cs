using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TP.Net.Hw.Consumer.Services.RabbitMq;

//Creating a builder to register services.
var host = Host.CreateDefaultBuilder().ConfigureServices((services) =>
        services.AddScoped<IConsumerService, ConsumerService>())
    .Build();


//Calling the consumer service.
var _consumer = host.Services.GetRequiredService<IConsumerService>();

//Giving the neccessary context
//IsAcnowledge can be made true. Therefore, messages will be automatically acknowledged.
_consumer.Consume(queueName: "direct.email", IsAcknowledgeAuto: false);

host.Run();