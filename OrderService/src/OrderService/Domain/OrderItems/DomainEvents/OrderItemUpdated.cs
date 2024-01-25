namespace OrderService.Domain.OrderItems.DomainEvents;

public sealed class OrderItemUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            