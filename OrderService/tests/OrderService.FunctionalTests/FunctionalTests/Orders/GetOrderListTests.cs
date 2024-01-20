namespace OrderService.FunctionalTests.FunctionalTests.Orders;

using OrderService.SharedTestHelpers.Fakes.Order;
using OrderService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetOrderListTests : TestBase
{
    [Fact]
    public async Task get_order_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Orders.GetList);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}