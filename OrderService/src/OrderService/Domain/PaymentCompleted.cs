using MassTransit;
using MediatR;
using OrderService.Databases;
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