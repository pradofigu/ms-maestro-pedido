namespace OrderService.SharedTestHelpers.Fakes.Order;

using AutoBogus;
using OrderService.Domain.Orders;
using OrderService.Domain.Orders.Models;

public sealed class FakeOrderForUpdate : AutoFaker<OrderForUpdate>
{
    public FakeOrderForUpdate()
    {
    }
}