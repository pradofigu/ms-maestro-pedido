namespace OrderService.Domain.Orders.Features;

using OrderService.Domain.Orders.Dtos;
using OrderService.Domain.Orders.Services;
using OrderService.Exceptions;
using Mappings;
using MediatR;

public static class GetOrder
{
    public sealed record Query(Guid OrderId) : IRequest<OrderDto>;

    public sealed class Handler : IRequestHandler<Query, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        public Handler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetById(request.OrderId, cancellationToken: cancellationToken);
            return result.ToOrderDto();
        }
    }
}