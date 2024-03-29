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
    public string Status { get; private set; }
    public string Method { get; private set; }
    public string CardNumber { get; private set; }
    public string CardToken { get; private set; }
    public string CardHolderName { get; private set; }
    public string ExpiryDate { get; private set; }
    public string CVV { get; private set; }
    public string Currency { get; private set; }
    public decimal TotalAmount { get; private set; }
    public Guid TransactionId { get; private set; }
    public Order Order { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    public static OrderPayment Create(OrderPaymentForCreation orderPaymentForCreation)
    {
        var newOrderPayment = new OrderPayment();

        newOrderPayment.OrderId = orderPaymentForCreation.OrderId;
        newOrderPayment.TransactionId = orderPaymentForCreation.TransactionId;
        newOrderPayment.Status = orderPaymentForCreation.Status;
        newOrderPayment.Method = orderPaymentForCreation.Method;
        newOrderPayment.TotalAmount = orderPaymentForCreation.TotalAmount;
        newOrderPayment.CardNumber = orderPaymentForCreation.CardNumber;
        newOrderPayment.CardToken = orderPaymentForCreation.CardToken;
        newOrderPayment.CardHolderName = orderPaymentForCreation.CardHolderName;
        newOrderPayment.ExpiryDate = orderPaymentForCreation.ExpiryDate;
        newOrderPayment.CVV = orderPaymentForCreation.CVV;
        newOrderPayment.Currency = orderPaymentForCreation.Currency;

        newOrderPayment.QueueDomainEvent(new OrderPaymentCreated(){ OrderPayment = newOrderPayment });
        
        return newOrderPayment;
    }

    public OrderPayment Update(OrderPaymentForUpdate orderPaymentForUpdate)
    {
        OrderId = orderPaymentForUpdate.OrderId;
        TransactionId = orderPaymentForUpdate.TransactionId;
        Status = orderPaymentForUpdate.Status;
        Method = orderPaymentForUpdate.Method;
        TotalAmount = orderPaymentForUpdate.TotalAmount;
        CardNumber = orderPaymentForUpdate.CardNumber;
        CardToken = orderPaymentForUpdate.CardToken;
        CardHolderName = orderPaymentForUpdate.CardHolderName;
        ExpiryDate = orderPaymentForUpdate.ExpiryDate;
        CVV = orderPaymentForUpdate.CVV;
        Currency = orderPaymentForUpdate.Currency;

        QueueDomainEvent(new OrderPaymentUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected OrderPayment() { } // For EF + Mocking
}
