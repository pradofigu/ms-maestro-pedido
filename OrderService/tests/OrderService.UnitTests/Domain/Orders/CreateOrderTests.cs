namespace OrderService.UnitTests.Domain.Orders;

using OrderService.SharedTestHelpers.Fakes.Order;
using OrderService.Domain.Orders;
using OrderService.Domain.Orders.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = OrderService.Exceptions.ValidationException;

public class CreateOrderTests
{
    private readonly Faker _faker;

    public CreateOrderTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_order()
    {
        // Arrange
        var orderToCreate = new FakeOrderForCreation().Generate();
        
        // Act
        var order = Order.Create(orderToCreate);

        // Assert
        order.Number.Should().Be(orderToCreate.Number);
        order.Status.Should().Be(orderToCreate.Status);
        order.CustomerNotes.Should().Be(orderToCreate.CustomerNotes);
        order.DiscountCode.Should().Be(orderToCreate.DiscountCode);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var orderToCreate = new FakeOrderForCreation().Generate();
        
        // Act
        var order = Order.Create(orderToCreate);

        // Assert
        order.DomainEvents.Count.Should().Be(1);
        order.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(OrderCreated));
    }
}