using MassTransit;
using MediatR;
using OpenTelemetry.Trace;
using OrderService.Databases;
using OrderService.Domain.Orders;
using OrderService.Domain.Orders.Dtos;
using OrderService.Domain.Orders.Features;
using OrderService.Domain.Orders.Mappings;
using OrderService.Services;
using SharedKernel.Messages;

namespace OrderService.Domain;

public sealed class PaymentCompleted : IConsumer<IPaymentCompleted>
{
    private readonly OrderDbContext _db;
    private readonly ISender _mediator;
    private readonly IPublishEndpoint _publishEndpoint;
    
    public PaymentCompleted(ISender mediator, IPublishEndpoint publishEndpoint, OrderDbContext db)
    {
        _mediator = mediator;
        _publishEndpoint = publishEndpoint;
        _db = db;
    }
    
    public async Task Consume(ConsumeContext<IPaymentCompleted> context)
    {
        var order = _db.Orders
            .First(x => x.CorrelationId == context.Message.CorrelationId);
        
        order.ChangeStatus("Em Preparo");
        
        await _db.SaveChangesAsync();
        
        if (context.Message.Status.Equals("Finalizada", StringComparison.CurrentCultureIgnoreCase))
        {
            await _publishEndpoint.Publish<IOrderPaid>(new
            {
                context.Message.CorrelationId,
                order.Number,
                Status = "Em Preparo"
            });
        }
        
        await _publishEndpoint.Publish<IOrderPaid>(new
        {
            context.Message.CorrelationId,
            order.Number,
            Status = "Cancelada"
        });
    }
}