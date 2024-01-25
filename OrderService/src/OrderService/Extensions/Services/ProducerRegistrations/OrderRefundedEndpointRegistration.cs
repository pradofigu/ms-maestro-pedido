namespace OrderService.Extensions.Services.ProducerRegistrations;

using MassTransit;
using MassTransit.RabbitMqTransport;
using SharedKernel.Messages;
using RabbitMQ.Client;

public static class OrderRefundedEndpointRegistration
{
    public static void OrderRefundedEndpoint(this IRabbitMqBusFactoryConfigurator cfg)
    {
        cfg.Message<IOrderRefunded>(e => e.SetEntityName("order-refunded")); // name of the primary exchange
        cfg.Publish<IOrderRefunded>(e => e.ExchangeType = ExchangeType.Fanout); // primary exchange type
    }
}