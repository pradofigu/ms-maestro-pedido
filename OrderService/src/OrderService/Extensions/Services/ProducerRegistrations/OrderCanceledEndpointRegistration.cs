namespace OrderService.Extensions.Services.ProducerRegistrations;

using MassTransit;
using MassTransit.RabbitMqTransport;
using SharedKernel.Messages;
using RabbitMQ.Client;

public static class OrderCanceledEndpointRegistration
{
    public static void OrderCanceledEndpoint(this IRabbitMqBusFactoryConfigurator cfg)
    {
        cfg.Message<IOrderCanceled>(e => e.SetEntityName("order-canceled")); // name of the primary exchange
        cfg.Publish<IOrderCanceled>(e => e.ExchangeType = ExchangeType.Fanout); // primary exchange type
    }
}