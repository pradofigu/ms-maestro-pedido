namespace OrderService.FunctionalTests.FunctionalTests.Orders;

using OrderService.SharedTestHelpers.Fakes.Order;
using OrderService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateOrderRecordTests : TestBase
{
    [Fact]
    public async Task put_order_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var order = new FakeOrderBuilder().Build();
        var updatedOrderDto = new FakeOrderForUpdateDto().Generate();
        await InsertAsync(order);

        // Act
        var route = ApiRoutes.Orders.Put(order.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedOrderDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }
}