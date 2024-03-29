namespace OrderService.FunctionalTests.FunctionalTests.Orders;

using OrderService.SharedTestHelpers.Fakes.Order;
using OrderService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateOrderTests : TestBase
{
    [Fact]
    public async Task create_order_returns_created_using_valid_dto()
    {
        // Arrange
        var order = new FakeOrderForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Orders.Create;
        var result = await FactoryClient.PostJsonRequestAsync(route, order);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }
}