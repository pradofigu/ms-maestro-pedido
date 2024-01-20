namespace OrderService.Domain.Orders.Features;

using OrderService.Domain.Orders;
using OrderService.Domain.Orders.Dtos;
using OrderService.Domain.Orders.Services;
using OrderService.Services;
using OrderService.Domain.Orders.Models;
using OrderService.Exceptions;
using Mappings;
using MediatR;

public static class UpdateOrder
{
    public sealed record Command(Guid OrderId, OrderForUpdateDto UpdatedOrderData) : IRequest;

    public sealed class Handler : IRequestHandler<Command>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetById(request.OrderId, cancellationToken: cancellationToken);
            var orderToAdd = request.UpdatedOrderData.ToOrderForUpdate();
            orderToUpdate.Update(orderToAdd);

            _orderRepository.Update(orderToUpdate);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}