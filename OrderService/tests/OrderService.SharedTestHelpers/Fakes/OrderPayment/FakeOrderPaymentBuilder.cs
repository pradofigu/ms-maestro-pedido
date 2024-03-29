namespace OrderService.SharedTestHelpers.Fakes.OrderPayment;

using OrderService.Domain.OrderPayments;
using OrderService.Domain.OrderPayments.Models;

public class FakeOrderPaymentBuilder
{
    private OrderPaymentForCreation _creationData = new FakeOrderPaymentForCreation().Generate();

    public FakeOrderPaymentBuilder WithModel(OrderPaymentForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeOrderPaymentBuilder WithOrderId(Guid orderId)
    {
        _creationData.OrderId = orderId;
        return this;
    }
    
    public FakeOrderPaymentBuilder WithPaymentStatus(string paymentStatus)
    {
        _creationData.Status = paymentStatus;
        return this;
    }
    
    public FakeOrderPaymentBuilder WithPaymentMethod(string paymentMethod)
    {
        _creationData.Method = paymentMethod;
        return this;
    }
    
    public FakeOrderPaymentBuilder WithAmountPaid(decimal amountPaid)
    {
        _creationData.TotalAmount = amountPaid;
        return this;
    }
    
    public FakeOrderPaymentBuilder WithTransactionId(Guid transactionId)
    {
        _creationData.TransactionId = transactionId;
        return this;
    }
    
    public OrderPayment Build()
    {
        var result = OrderPayment.Create(_creationData);
        return result;
    }
}