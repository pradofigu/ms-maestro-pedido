using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace OrderService.Domain.OrderPayments;

using OrderService.Domain.Orders;
using OrderService.Domain.OrderPayments.Models;
using OrderService.Domain.OrderPayments.DomainEvents;


public class OrderPayment : BaseEntity
{
    [JsonIgnore, IgnoreDataMember]

    public Guid OrderId { get; private set; }

    public string PaymentStatus { get; private set; }

    public string PaymentMethod { get; private set; }

    public decimal AmountPaid { get; private set; }

    public Guid TransactionId { get; private set; }

    public Order Order { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static OrderPayment Create(OrderPaymentForCreation orderPaymentForCreation)
    {
        var newOrderPayment = new OrderPayment();

        newOrderPayment.OrderId = orderPaymentForCreation.OrderId;
        newOrderPayment.PaymentStatus = orderPaymentForCreation.PaymentStatus;
        newOrderPayment.PaymentMethod = orderPaymentForCreation.PaymentMethod;
        newOrderPayment.AmountPaid = orderPaymentForCreation.AmountPaid;
        newOrderPayment.TransactionId = orderPaymentForCreation.TransactionId;

        newOrderPayment.QueueDomainEvent(new OrderPaymentCreated(){ OrderPayment = newOrderPayment });
        
        return newOrderPayment;
    }

    public OrderPayment Update(OrderPaymentForUpdate orderPaymentForUpdate)
    {
        OrderId = orderPaymentForUpdate.OrderId;
        PaymentStatus = orderPaymentForUpdate.PaymentStatus;
        PaymentMethod = orderPaymentForUpdate.PaymentMethod;
        AmountPaid = orderPaymentForUpdate.AmountPaid;
        TransactionId = orderPaymentForUpdate.TransactionId;

        QueueDomainEvent(new OrderPaymentUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected OrderPayment() { } // For EF + Mocking
}
