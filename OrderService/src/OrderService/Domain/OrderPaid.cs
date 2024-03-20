using OrderService.Domain.Orders;

namespace OrderService.Domain;

using SharedKernel.Messages;
using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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