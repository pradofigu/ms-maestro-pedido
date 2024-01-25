namespace OrderService.IntegrationTests.FeatureTests.Orders;

using OrderService.Domain.Orders.Dtos;
using OrderService.SharedTestHelpers.Fakes.Order;
using OrderService.Domain.Orders.Features;
using Domain;
using System.Threading.Tasks;

public class OrderListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_order_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var orderOne = new FakeOrderBuilder().Build();
        var orderTwo = new FakeOrderBuilder().Build();
        var queryParameters = new OrderParametersDto();

        await testingServiceScope.InsertAsync(orderOne, orderTwo);

        // Act
        var query = new GetOrderList.Query(queryParameters);
        var orders = await testingServiceScope.SendAsync(query);

        // Assert
        orders.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}