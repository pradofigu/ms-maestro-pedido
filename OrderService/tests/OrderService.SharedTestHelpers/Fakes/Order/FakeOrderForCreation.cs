namespace OrderService.SharedTestHelpers.Fakes.Order;

using AutoBogus;
using OrderService.Domain.Orders;
using OrderService.Domain.Orders.Models;

public sealed class FakeOrderForCreation : AutoFaker<OrderForCreation>
{
    public FakeOrderForCreation()
    {
    }
}