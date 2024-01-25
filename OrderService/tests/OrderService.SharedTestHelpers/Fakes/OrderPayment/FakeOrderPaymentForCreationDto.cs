namespace OrderService.SharedTestHelpers.Fakes.OrderPayment;

using AutoBogus;
using OrderService.Domain.OrderPayments;
using OrderService.Domain.OrderPayments.Dtos;

public sealed class FakeOrderPaymentForCreationDto : AutoFaker<OrderPaymentForCreationDto>
{
    public FakeOrderPaymentForCreationDto()
    {
    }
}