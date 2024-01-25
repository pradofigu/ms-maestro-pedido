namespace OrderService.Domain.Orders.DomainEvents;

public sealed class OrderUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            