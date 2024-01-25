namespace OrderService.FunctionalTests.FunctionalTests.Orders;

using OrderService.SharedTestHelpers.Fakes.Order;
using OrderService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetOrderTests : TestBase
{
    [Fact]
    public async Task get_order_returns_success_when_entity_exists()
    {
        // Arrange
        var order = new FakeOrderBuilder().Build();
        await InsertAsync(order);

        // Act
        var route = ApiRoutes.Orders.GetRecord(order.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}