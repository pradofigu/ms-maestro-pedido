namespace OrderService.Extensions.Services.ProducerRegistrations;

using MassTransit;
using MassTransit.RabbitMqTransport;
using SharedKernel.Messages;
using RabbitMQ.Client;

public static class OrderPaidEndpointRegistration
{
    public static void OrderPaidEndpoint(this IRabbitMqBusFactoryConfigurator cfg)
    {
        cfg.Message<IOrderPaid>(e => e.SetEntityName("order-paid")); // name of the primary exchange
        cfg.Publish<IOrderPaid>(e => e.ExchangeType = ExchangeType.Fanout); // primary exchange type
    }
}