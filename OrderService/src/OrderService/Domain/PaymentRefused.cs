using MassTransit;
using MediatR;
using OrderService.Databases;
using SharedKernel.Messages;

namespace OrderService.Domain;

public sealed class PaymentRefused : IConsumer<IPaymentRefused>
{
    private readonly ISender _mediator;
    private readonly OrderDbContext _db;

    public PaymentRefused(ISender mediator, OrderDbContext db)
    {
        _mediator = mediator;
        _db = db;
    }

    public async Task Consume(ConsumeContext<IPaymentRefused> context)
    {
        var order = _db.Orders
            .First(x => x.CorrelationId == context.Message.CorrelationId);
        
        order.ChangeStatus("Cancelado");
        
        await _db.SaveChangesAsync();
        var command = new OrderCanceled.OrderCanceledCommand(order);
        await _mediator.Send(command);
    }
}