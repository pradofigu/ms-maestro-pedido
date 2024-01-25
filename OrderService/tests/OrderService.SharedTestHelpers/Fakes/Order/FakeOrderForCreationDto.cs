namespace OrderService.SharedTestHelpers.Fakes.Order;

using AutoBogus;
using OrderService.Domain.Orders;
using OrderService.Domain.Orders.Dtos;

public sealed class FakeOrderForCreationDto : AutoFaker<OrderForCreationDto>
{
    public FakeOrderForCreationDto()
    {
    }
}