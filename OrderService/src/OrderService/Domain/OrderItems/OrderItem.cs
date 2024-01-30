namespace OrderService.Domain.OrderItems;

using OrderService.Domain.Orders;
using OrderService.Domain.OrderItems.Models;
using OrderService.Domain.OrderItems.DomainEvents;

public class OrderItem : BaseEntity
{
    public string Description { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal TotalPrice { get; private set; }

    public Order Order { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static OrderItem Create(OrderItemForCreation orderItemForCreation)
    {
        var newOrderItem = new OrderItem();

        newOrderItem.Description = orderItemForCreation.Description;
        newOrderItem.Quantity = orderItemForCreation.Quantity;
        newOrderItem.UnitPrice = orderItemForCreation.UnitPrice;
        newOrderItem.TotalPrice = orderItemForCreation.TotalPrice;

        newOrderItem.QueueDomainEvent(new OrderItemCreated(){ OrderItem = newOrderItem });
        
        return newOrderItem;
    }

    public OrderItem Update(OrderItemForUpdate orderItemForUpdate)
    {
        Description = orderItemForUpdate.Description;
        Quantity = orderItemForUpdate.Quantity;
        UnitPrice = orderItemForUpdate.UnitPrice;
        TotalPrice = orderItemForUpdate.TotalPrice;

        QueueDomainEvent(new OrderItemUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected OrderItem() { } // For EF + Mocking
}
