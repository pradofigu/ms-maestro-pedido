using MediatR;
using OrderService.Domain.Orders.Dtos;
using OrderService.Domain.Orders.Mappings;
using OrderService.Domain.Orders.Services;
using OrderService.Services;

namespace OrderService.Domain.Orders.Features;

public static class UpdateOrderByCorrelation
{
    public sealed record Command(Guid CorrelationId, OrderForUpdateDto UpdatedOrderData) : IRequest<OrderDto>;
    
    public sealed class Handler : IRequestHandler<Command, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public Handler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<OrderDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByCorrelationIdAsync(request.CorrelationId, cancellationToken: cancellationToken);
            var orderToAdd = request.UpdatedOrderData.ToOrderForUpdate();
            orderToUpdate.Update(orderToAdd);

            _orderRepository.Update(orderToUpdate);
            await _unitOfWork.CommitChanges(cancellationToken);

            return orderToUpdate.ToOrderDto();
        }
    }
}