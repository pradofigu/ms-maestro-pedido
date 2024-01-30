namespace OrderService.SharedTestHelpers.Fakes.OrderItem;

using AutoBogus;
using OrderService.Domain.OrderItems;
using OrderService.Domain.OrderItems.Dtos;

public sealed class FakeOrderItemForUpdateDto : AutoFaker<OrderItemForUpdateDto>
{
    public FakeOrderItemForUpdateDto()
    {
    }
}