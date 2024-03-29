namespace OrderService.IntegrationTests.FeatureTests.Orders;

using OrderService.SharedTestHelpers.Fakes.Order;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using OrderService.Domain.Orders.Features;

public class AddOrderCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_order_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var orderOne = new FakeOrderForCreationDto().Generate();

        // Act
        var command = new AddOrder.Command(orderOne);
        var orderReturned = await testingServiceScope.SendAsync(command);
        var orderCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Orders
            .FirstOrDefaultAsync(o => o.Id == orderReturned.Id));

        // Assert
        // orderReturned.Number.Should().Be(orderOne.Number);
        // orderReturned.Status.Should().Be(orderOne.Status);
        orderReturned.CustomerNotes.Should().Be(orderOne.CustomerNotes);
        orderReturned.DiscountCode.Should().Be(orderOne.DiscountCode);

        // orderCreated.Number.Should().Be(orderOne.Number);
        // orderCreated.Status.Should().Be(orderOne.Status);
        orderCreated.CustomerNotes.Should().Be(orderOne.CustomerNotes);
        orderCreated.DiscountCode.Should().Be(orderOne.DiscountCode);
    }
}