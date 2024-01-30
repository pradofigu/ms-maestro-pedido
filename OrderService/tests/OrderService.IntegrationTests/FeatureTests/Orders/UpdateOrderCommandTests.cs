namespace OrderService.IntegrationTests.FeatureTests.Orders;

using OrderService.SharedTestHelpers.Fakes.Order;
using OrderService.Domain.Orders.Dtos;
using OrderService.Domain.Orders.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateOrderCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_order_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var order = new FakeOrderBuilder().Build();
        await testingServiceScope.InsertAsync(order);
        var updatedOrderDto = new FakeOrderForUpdateDto().Generate();

        // Act
        var command = new UpdateOrder.Command(order.Id, updatedOrderDto);
        await testingServiceScope.SendAsync(command);
        var updatedOrder = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Orders
                .FirstOrDefaultAsync(o => o.Id == order.Id));

        // Assert
        updatedOrder.Number.Should().Be(updatedOrderDto.Number);
        updatedOrder.Status.Should().Be(updatedOrderDto.Status);
        updatedOrder.CustomerNotes.Should().Be(updatedOrderDto.CustomerNotes);
        updatedOrder.TotalAmount.Should().Be(updatedOrderDto.TotalAmount);
        updatedOrder.DiscountCode.Should().Be(updatedOrderDto.DiscountCode);
    }
}