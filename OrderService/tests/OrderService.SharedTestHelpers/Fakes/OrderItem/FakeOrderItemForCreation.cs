namespace OrderService.SharedTestHelpers.Fakes.OrderItem;

using AutoBogus;
using OrderService.Domain.OrderItems;
using OrderService.Domain.OrderItems.Models;

public sealed class FakeOrderItemForCreation : AutoFaker<OrderItemForCreation>
{
    public FakeOrderItemForCreation()
    {
    }
}