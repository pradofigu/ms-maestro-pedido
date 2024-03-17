namespace OrderService.Domain.Orders.Features;

using OrderService.Domain.Orders.Services;
using OrderService.Domain.Orders;
using OrderService.Domain.Orders.Dtos;
using OrderService.Domain.Orders.Models;
using OrderService.Services;
using OrderService.Exceptions;
using Mappings;
using MediatR;

public static class AddOrder
{
    public sealed record Command(OrderForCreationDto OrderToAdd) : IRequest<OrderDto>;

    public sealed class Handler : IRequestHandler<Command, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISender _mediator;

        public Handler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, ISender mediator)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<OrderDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var orderToAdd = request.OrderToAdd.ToOrderForCreation();
            var order = Order.Create(orderToAdd);

            await _orderRepository.Add(order, cancellationToken);
            await _unitOfWork.CommitChanges(cancellationToken);
            
            //TODO: Add to Domain Event
            var command = new OrderCreated.OrderCreatedCommand(order);
            await _mediator.Send(command, cancellationToken);
            
            return order.ToOrderDto();
        }
    }
}