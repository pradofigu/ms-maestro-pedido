namespace OrderService.Domain.OrderItems.DomainEvents;

public sealed class OrderItemCreated : DomainEvent
{
    public OrderItem OrderItem { get; set; } 
}
            