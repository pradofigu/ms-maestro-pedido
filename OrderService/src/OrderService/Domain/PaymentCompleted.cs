using MassTransit;
using OrderService.Services;
using SharedKernel.Messages;

namespace OrderService.Domain;

public sealed class PaymentCompleted : IConsumer<IPaymentCompleted>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public PaymentCompleted(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Task Consume(ConsumeContext<IPaymentCompleted> context)
    {
        return Task.CompletedTask;
    }
}