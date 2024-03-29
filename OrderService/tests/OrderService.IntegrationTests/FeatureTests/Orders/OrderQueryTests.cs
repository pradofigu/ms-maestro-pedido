namespace OrderService.IntegrationTests.FeatureTests.Orders;

using OrderService.SharedTestHelpers.Fakes.Order;
using OrderService.Domain.Orders.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class OrderQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_order_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var orderOne = new FakeOrderBuilder().Build();
        await testingServiceScope.InsertAsync(orderOne);

        // Act
        var query = new GetOrder.Query(orderOne.Id);
        var order = await testingServiceScope.SendAsync(query);

        // Assert
        order.Number.Should().Be(orderOne.Number);
        order.Status.Should().Be(orderOne.Status);
        order.CustomerNotes.Should().Be(orderOne.CustomerNotes);
        order.DiscountCode.Should().Be(orderOne.DiscountCode);
    }

    [Fact]
    public async Task get_order_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetOrder.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}