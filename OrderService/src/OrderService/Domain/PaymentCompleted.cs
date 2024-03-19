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
    private readonly ISender _mediator;
    private readonly OrderDbContext _db;
    
    public PaymentCompleted(ISender mediator, OrderDbContext db)
    {
        _mediator = mediator;
        _db = db;
    }
    
    public async Task Consume(ConsumeContext<IPaymentCompleted> context)
    {
        var order = _db.Orders
            .First(x => x.CorrelationId == context.Message.CorrelationId);
        
        order.ChangeStatus("Em Preparo");
        
        await _db.SaveChangesAsync();
        var command = new OrderPaid.OrderPaidCommand(order);
        await _mediator.Send(command);
    }
}