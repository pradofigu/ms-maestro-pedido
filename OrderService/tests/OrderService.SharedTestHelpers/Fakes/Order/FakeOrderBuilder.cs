namespace OrderService.SharedTestHelpers.Fakes.Order;

using OrderService.Domain.Orders;
using OrderService.Domain.Orders.Models;

public class FakeOrderBuilder
{
    private OrderForCreation _creationData = new FakeOrderForCreation().Generate();

    public FakeOrderBuilder WithModel(OrderForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeOrderBuilder WithNumber(int number)
    {
        _creationData.Number = number;
        return this;
    }
    
    public FakeOrderBuilder WithStatus(string status)
    {
        _creationData.Status = status;
        return this;
    }
    
    public FakeOrderBuilder WithCustomerNotes(string customerNotes)
    {
        _creationData.CustomerNotes = customerNotes;
        return this;
    }
    
    public FakeOrderBuilder WithTotalAmount(string totalAmount)
    {
        _creationData.TotalAmount = totalAmount;
        return this;
    }
    
    public FakeOrderBuilder WithDiscountCode(string discountCode)
    {
        _creationData.DiscountCode = discountCode;
        return this;
    }
    
    public Order Build()
    {
        var result = Order.Create(_creationData);
        return result;
    }
}