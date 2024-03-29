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

        public Handler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(OrderCreatedCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IOrderCreated>(new
            {
                OrderId = request.Order.Id,
                request.Order.CorrelationId,
                request.Order.Number,
                request.Order.Status,
                request.Order.OrderPayment.TotalAmount,
                request.Order.OrderPayment.CardNumber,
                request.Order.OrderPayment.CardToken,
                request.Order.OrderPayment.CardHolderName,
                request.Order.OrderPayment.ExpiryDate,
                request.Order.OrderPayment.CVV,
                request.Order.OrderPayment.Currency,
            }, cancellationToken);

            return true;
        }
    }
}