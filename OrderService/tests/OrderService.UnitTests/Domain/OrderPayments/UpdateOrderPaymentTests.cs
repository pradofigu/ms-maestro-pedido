namespace OrderService.UnitTests.Domain.OrderPayments;

using OrderService.SharedTestHelpers.Fakes.OrderPayment;
using OrderService.Domain.OrderPayments;
using OrderService.Domain.OrderPayments.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = OrderService.Exceptions.ValidationException;

public class UpdateOrderPaymentTests
{
    private readonly Faker _faker;

    public UpdateOrderPaymentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_orderPayment()
    {
        // Arrange
        var orderPayment = new FakeOrderPaymentBuilder().Build();
        var updatedOrderPayment = new FakeOrderPaymentForUpdate().Generate();
        
        // Act
        orderPayment.Update(updatedOrderPayment);

        // Assert
        orderPayment.OrderId.Should().Be(updatedOrderPayment.OrderId);
        orderPayment.PaymentStatus.Should().Be(updatedOrderPayment.PaymentStatus);
        orderPayment.PaymentMethod.Should().Be(updatedOrderPayment.PaymentMethod);
        orderPayment.AmountPaid.Should().Be(updatedOrderPayment.AmountPaid);
        orderPayment.TransactionId.Should().Be(updatedOrderPayment.TransactionId);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var orderPayment = new FakeOrderPaymentBuilder().Build();
        var updatedOrderPayment = new FakeOrderPaymentForUpdate().Generate();
        orderPayment.DomainEvents.Clear();
        
        // Act
        orderPayment.Update(updatedOrderPayment);

        // Assert
        orderPayment.DomainEvents.Count.Should().Be(1);
        orderPayment.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(OrderPaymentUpdated));
    }
}