namespace OrderService.UnitTests.Domain.OrderPayments;

using OrderService.SharedTestHelpers.Fakes.OrderPayment;
using OrderService.Domain.OrderPayments;
using OrderService.Domain.OrderPayments.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = OrderService.Exceptions.ValidationException;

public class CreateOrderPaymentTests
{
    private readonly Faker _faker;

    public CreateOrderPaymentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_orderPayment()
    {
        // Arrange
        var orderPaymentToCreate = new FakeOrderPaymentForCreation().Generate();
        
        // Act
        var orderPayment = OrderPayment.Create(orderPaymentToCreate);

        // Assert
        orderPayment.OrderId.Should().Be(orderPaymentToCreate.OrderId);
        orderPayment.Status.Should().Be(orderPaymentToCreate.Status);
        orderPayment.Method.Should().Be(orderPaymentToCreate.Method);
        orderPayment.TotalAmount.Should().Be(orderPaymentToCreate.TotalAmount);
        orderPayment.TransactionId.Should().Be(orderPaymentToCreate.TransactionId);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var orderPaymentToCreate = new FakeOrderPaymentForCreation().Generate();
        
        // Act
        var orderPayment = OrderPayment.Create(orderPaymentToCreate);

        // Assert
        orderPayment.DomainEvents.Count.Should().Be(1);
        orderPayment.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(OrderPaymentCreated));
    }
}