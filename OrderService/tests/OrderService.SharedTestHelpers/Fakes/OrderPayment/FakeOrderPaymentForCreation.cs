namespace OrderService.SharedTestHelpers.Fakes.OrderPayment;

using AutoBogus;
using OrderService.Domain.OrderPayments;
using OrderService.Domain.OrderPayments.Models;

public sealed class FakeOrderPaymentForCreation : AutoFaker<OrderPaymentForCreation>
{
    public FakeOrderPaymentForCreation()
    {
    }
}