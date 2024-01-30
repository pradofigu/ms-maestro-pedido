namespace OrderService.SharedTestHelpers.Fakes.OrderPayment;

using AutoBogus;
using OrderService.Domain.OrderPayments;
using OrderService.Domain.OrderPayments.Dtos;

public sealed class FakeOrderPaymentForUpdateDto : AutoFaker<OrderPaymentForUpdateDto>
{
    public FakeOrderPaymentForUpdateDto()
    {
    }
}