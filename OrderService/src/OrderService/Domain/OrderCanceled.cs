using OrderService.Domain.Orders;

namespace OrderService.Domain;

using SharedKernel.Messages;
using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public static class OrderCanceled
{
    public sealed record OrderCanceledCommand(Order Order) : IRequest<bool>;

    public sealed class Handler : IRequestHandler<OrderCanceledCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public Handler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(OrderCanceledCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IOrderCanceled>(new
            {
                request.Order.CorrelationId,
                request.Order.Number,
                Status = "Cancelado"
            }, cancellationToken);

            return true;
        }
    }
}