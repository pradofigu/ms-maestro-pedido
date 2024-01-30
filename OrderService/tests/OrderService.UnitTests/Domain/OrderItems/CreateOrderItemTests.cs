namespace OrderService.UnitTests.Domain.OrderItems;

using OrderService.SharedTestHelpers.Fakes.OrderItem;
using OrderService.Domain.OrderItems;
using OrderService.Domain.OrderItems.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = OrderService.Exceptions.ValidationException;

public class CreateOrderItemTests
{
    private readonly Faker _faker;

    public CreateOrderItemTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_orderItem()
    {
        // Arrange
        var orderItemToCreate = new FakeOrderItemForCreation().Generate();
        
        // Act
        var orderItem = OrderItem.Create(orderItemToCreate);

        // Assert
        orderItem.Description.Should().Be(orderItemToCreate.Description);
        orderItem.Quantity.Should().Be(orderItemToCreate.Quantity);
        orderItem.UnitPrice.Should().Be(orderItemToCreate.UnitPrice);
        orderItem.TotalPrice.Should().Be(orderItemToCreate.TotalPrice);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var orderItemToCreate = new FakeOrderItemForCreation().Generate();
        
        // Act
        var orderItem = OrderItem.Create(orderItemToCreate);

        // Assert
        orderItem.DomainEvents.Count.Should().Be(1);
        orderItem.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(OrderItemCreated));
    }
}