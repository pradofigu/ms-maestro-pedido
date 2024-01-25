namespace OrderService.Domain;

using SharedKernel.Messages;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using OrderService.Databases;

public static class OrderPaid
{
    public sealed record OrderPaidCommand() : IRequest<bool>;

    public sealed class Handler : IRequestHandler<OrderPaidCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly OrderDbContext _db;

        public Handler(OrderDbContext db, IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _db = db;
        }

        public async Task<bool> Handle(OrderPaidCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IOrderPaid>(new { });

            return true;
        }
    }
}