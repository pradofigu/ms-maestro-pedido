namespace OrderService.Domain.OrderPayments.DomainEvents;

public sealed class OrderPaymentCreated : DomainEvent
{
    public OrderPayment OrderPayment { get; set; } 
}
            