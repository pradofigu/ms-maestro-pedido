namespace OrderService.Domain.Orders.Features;

using OrderService.Domain.Orders.Services;
using OrderService.Services;
using OrderService.Exceptions;
using MediatR;

public static class DeleteOrder
{
    public sealed record Command(Guid OrderId) : IRequest;

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
            var recordToDelete = await _orderRepository.GetById(request.OrderId, cancellationToken: cancellationToken);
            _orderRepository.Remove(recordToDelete);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}