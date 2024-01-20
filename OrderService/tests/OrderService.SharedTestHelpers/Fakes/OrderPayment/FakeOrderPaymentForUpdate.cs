namespace OrderService.SharedTestHelpers.Fakes.OrderPayment;

using AutoBogus;
using OrderService.Domain.OrderPayments;
using OrderService.Domain.OrderPayments.Models;

public sealed class FakeOrderPaymentForUpdate : AutoFaker<OrderPaymentForUpdate>
{
    public FakeOrderPaymentForUpdate()
    {
    }
}