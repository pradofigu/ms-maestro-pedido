namespace OrderService.UnitTests.Domain.OrderItems;

using OrderService.SharedTestHelpers.Fakes.OrderItem;
using OrderService.Domain.OrderItems;
using OrderService.Domain.OrderItems.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = OrderService.Exceptions.ValidationException;

public class UpdateOrderItemTests
{
    private readonly Faker _faker;

    public UpdateOrderItemTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_orderItem()
    {
        // Arrange
        var orderItem = new FakeOrderItemBuilder().Build();
        var updatedOrderItem = new FakeOrderItemForUpdate().Generate();
        
        // Act
        orderItem.Update(updatedOrderItem);

        // Assert
        orderItem.Description.Should().Be(updatedOrderItem.Description);
        orderItem.Quantity.Should().Be(updatedOrderItem.Quantity);
        orderItem.UnitPrice.Should().Be(updatedOrderItem.UnitPrice);
        orderItem.TotalPrice.Should().Be(updatedOrderItem.TotalPrice);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var orderItem = new FakeOrderItemBuilder().Build();
        var updatedOrderItem = new FakeOrderItemForUpdate().Generate();
        orderItem.DomainEvents.Clear();
        
        // Act
        orderItem.Update(updatedOrderItem);

        // Assert
        orderItem.DomainEvents.Count.Should().Be(1);
        orderItem.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(OrderItemUpdated));
    }
}