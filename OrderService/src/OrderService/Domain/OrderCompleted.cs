namespace OrderService.Domain;

using SharedKernel.Messages;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using OrderService.Databases;

public class OrderCompleted : IConsumer<IOrderCompleted>
{
    private readonly OrderDbContext _db;

    public OrderCompleted(OrderDbContext db)
    {
        _db = db;
    }

    public async Task Consume(ConsumeContext<IOrderCompleted> context)
    {
        var order = _db.Orders
            .First(x => x.CorrelationId == context.Message.CorrelationId);
        
        order.ChangeStatus(context.Message.Status);
        
        await _db.SaveChangesAsync();
    }
}