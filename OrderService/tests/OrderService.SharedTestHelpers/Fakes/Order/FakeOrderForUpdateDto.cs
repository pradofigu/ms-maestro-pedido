namespace OrderService.SharedTestHelpers.Fakes.Order;

using AutoBogus;
using OrderService.Domain.Orders;
using OrderService.Domain.Orders.Dtos;

public sealed class FakeOrderForUpdateDto : AutoFaker<OrderForUpdateDto>
{
    public FakeOrderForUpdateDto()
    {
    }
}