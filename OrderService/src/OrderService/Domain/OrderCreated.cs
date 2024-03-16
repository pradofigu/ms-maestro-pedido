using OrderService.Domain.Orders;

namespace OrderService.Domain;

using SharedKernel.Messages;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using OrderService.Databases;

public static class OrderCreated
{
    public sealed record OrderCreatedCommand(Order Order) : IRequest<bool>;

    public sealed class Handler : IRequestHandler<OrderCreatedCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly OrderDbContext _db;

        public Handler(OrderDbContext db, IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _db = db;
        }

        public async Task<bool> Handle(OrderCreatedCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IOrderCreated>(new
            {
                CorrelationId = Guid.NewGuid().ToString(),
                OrderId = request.Order.Id,
                request.Order.Number,
                request.Order.Status,
                request.Order.TotalAmount,
                request.Order.DiscountCode,
            }, cancellationToken);

            return true;
        }
    }
}