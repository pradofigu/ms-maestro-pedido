namespace OrderService.Domain.OrderPayments.DomainEvents;

public sealed class OrderPaymentUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            