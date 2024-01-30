namespace OrderService.SharedTestHelpers.Fakes.OrderItem;

using OrderService.Domain.OrderItems;
using OrderService.Domain.OrderItems.Models;

public class FakeOrderItemBuilder
{
    private OrderItemForCreation _creationData = new FakeOrderItemForCreation().Generate();

    public FakeOrderItemBuilder WithModel(OrderItemForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeOrderItemBuilder WithDescription(string description)
    {
        _creationData.Description = description;
        return this;
    }
    
    public FakeOrderItemBuilder WithQuantity(int quantity)
    {
        _creationData.Quantity = quantity;
        return this;
    }
    
    public FakeOrderItemBuilder WithUnitPrice(decimal unitPrice)
    {
        _creationData.UnitPrice = unitPrice;
        return this;
    }
    
    public FakeOrderItemBuilder WithTotalPrice(decimal totalPrice)
    {
        _creationData.TotalPrice = totalPrice;
        return this;
    }
    
    public OrderItem Build()
    {
        var result = OrderItem.Create(_creationData);
        return result;
    }
}