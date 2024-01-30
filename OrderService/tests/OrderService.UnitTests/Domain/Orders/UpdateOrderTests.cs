namespace OrderService.UnitTests.Domain.Orders;

using OrderService.SharedTestHelpers.Fakes.Order;
using OrderService.Domain.Orders;
using OrderService.Domain.Orders.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = OrderService.Exceptions.ValidationException;

public class UpdateOrderTests
{
    private readonly Faker _faker;

    public UpdateOrderTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_order()
    {
        // Arrange
        var order = new FakeOrderBuilder().Build();
        var updatedOrder = new FakeOrderForUpdate().Generate();
        
        // Act
        order.Update(updatedOrder);

        // Assert
        order.Number.Should().Be(updatedOrder.Number);
        order.Status.Should().Be(updatedOrder.Status);
        order.CustomerNotes.Should().Be(updatedOrder.CustomerNotes);
        order.TotalAmount.Should().Be(updatedOrder.TotalAmount);
        order.DiscountCode.Should().Be(updatedOrder.DiscountCode);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var order = new FakeOrderBuilder().Build();
        var updatedOrder = new FakeOrderForUpdate().Generate();
        order.DomainEvents.Clear();
        
        // Act
        order.Update(updatedOrder);

        // Assert
        order.DomainEvents.Count.Should().Be(1);
        order.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(OrderUpdated));
    }
}