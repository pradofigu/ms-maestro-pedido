namespace OrderService.FunctionalTests.FunctionalTests.Orders;

using OrderService.SharedTestHelpers.Fakes.Order;
using OrderService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteOrderTests : TestBase
{
    [Fact]
    public async Task delete_order_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var order = new FakeOrderBuilder().Build();
        await InsertAsync(order);

        // Act
        var route = ApiRoutes.Orders.Delete(order.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}