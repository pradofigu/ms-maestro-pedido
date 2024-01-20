namespace OrderService.Extensions.Services.ProducerRegistrations;

using MassTransit;
using MassTransit.RabbitMqTransport;
using SharedKernel.Messages;
using RabbitMQ.Client;

public static class OrderCreatedEndpointRegistration
{
    public static void OrderCreatedEndpoint(this IRabbitMqBusFactoryConfigurator cfg)
    {
        cfg.Message<IOrderCreated>(e => e.SetEntityName("order-created")); // name of the primary exchange
        cfg.Publish<IOrderCreated>(e => e.ExchangeType = ExchangeType.Fanout); // primary exchange type
    }
}