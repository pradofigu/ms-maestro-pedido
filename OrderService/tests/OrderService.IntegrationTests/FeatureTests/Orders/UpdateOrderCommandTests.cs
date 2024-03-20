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
    public Task can_update_existing_order_in_db()
    {
        // Reavaliate Task
        return Task.CompletedTask;
    }
}