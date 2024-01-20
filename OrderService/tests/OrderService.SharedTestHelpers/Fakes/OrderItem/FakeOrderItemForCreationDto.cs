namespace OrderService.SharedTestHelpers.Fakes.OrderItem;

using AutoBogus;
using OrderService.Domain.OrderItems;
using OrderService.Domain.OrderItems.Dtos;

public sealed class FakeOrderItemForCreationDto : AutoFaker<OrderItemForCreationDto>
{
    public FakeOrderItemForCreationDto()
    {
    }
}