using OrderService.Domain.Orders;

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
    public sealed record OrderPaidCommand(Order Order) : IRequest<bool>;

    public sealed class Handler : IRequestHandler<OrderPaidCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public Handler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(OrderPaidCommand request, CancellationToken cancellationToken)
        {
            if (request.Order.Status.Equals("Finalizada", StringComparison.CurrentCultureIgnoreCase))
            {
                await _publishEndpoint.Publish<IOrderPaid>(new
                {
                    request.Order.CorrelationId,
                    request.Order.Number,
                    Status = "Em Preparo"
                }, cancellationToken);
            }
            
            await _publishEndpoint.Publish<IOrderPaid>(new
            {
                request.Order.CorrelationId,
                request.Order.Number,
                Status = "Em Preparo"
            }, cancellationToken);
            
            return true;
        }
    }
}