namespace OrderService.Domain.Orders;

using System.ComponentModel.DataAnnotations;
using OrderService.Domain.OrderPayments;
using OrderService.Domain.OrderPayments.Models;
using OrderService.Domain.OrderItems;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using OrderService.Exceptions;
using OrderService.Domain.Orders.Models;
using OrderService.Domain.Orders.DomainEvents;
using OrderService.Domain.OrderItems;
using OrderService.Domain.OrderItems.Models;
using OrderService.Domain.OrderPayments;
using OrderService.Domain.OrderPayments.Models;


public class Order : BaseEntity
{
    public int Number { get; private set; }

    public string Status { get; private set; }

    public string CustomerNotes { get; private set; }

    public string TotalAmount { get; private set; }

    public string DiscountCode { get; private set; }

    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public OrderPayment OrderPayment { get; private set; } = OrderPayment.Create(new OrderPaymentForCreation());

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Order Create(OrderForCreation orderForCreation)
    {
        var newOrder = new Order();

        newOrder.Number = orderForCreation.Number;
        newOrder.Status = orderForCreation.Status;
        newOrder.CustomerNotes = orderForCreation.CustomerNotes;
        newOrder.TotalAmount = orderForCreation.TotalAmount;
        newOrder.DiscountCode = orderForCreation.DiscountCode;

        newOrder.QueueDomainEvent(new OrderCreated(){ Order = newOrder });
        
        return newOrder;
    }

    public Order Update(OrderForUpdate orderForUpdate)
    {
        Number = orderForUpdate.Number;
        Status = orderForUpdate.Status;
        CustomerNotes = orderForUpdate.CustomerNotes;
        TotalAmount = orderForUpdate.TotalAmount;
        DiscountCode = orderForUpdate.DiscountCode;

        QueueDomainEvent(new OrderUpdated(){ Id = Id });
        return this;
    }

    public Order AddOrderItem(OrderItem orderItem)
    {
        _orderItems.Add(orderItem);
        return this;
    }
    
    public Order RemoveOrderItem(OrderItem orderItem)
    {
        _orderItems.RemoveAll(x => x.Id == orderItem.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Order() { } // For EF + Mocking
}
