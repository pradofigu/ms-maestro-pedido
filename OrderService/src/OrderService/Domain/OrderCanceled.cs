namespace OrderService.Domain;

using SharedKernel.Messages;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using OrderService.Databases;

public static class OrderCanceled
{
    public sealed record OrderCanceledCommand() : IRequest<bool>;

    public sealed class Handler : IRequestHandler<OrderCanceledCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly OrderDbContext _db;

        public Handler(OrderDbContext db, IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _db = db;
        }

        public async Task<bool> Handle(OrderCanceledCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IOrderCanceled>(new { });

            return true;
        }
    }
}