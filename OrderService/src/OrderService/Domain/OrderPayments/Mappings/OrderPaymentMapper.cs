namespace OrderService.Domain.OrderPayments.Mappings;

using OrderService.Domain.OrderPayments.Dtos;
using OrderService.Domain.OrderPayments.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class OrderPaymentMapper
{
    public static partial OrderPaymentForCreation ToOrderPaymentForCreation(this OrderPaymentForCreationDto orderPaymentForCreationDto);
    public static partial OrderPaymentForUpdate ToOrderPaymentForUpdate(this OrderPaymentForUpdateDto orderPaymentForUpdateDto);
    public static partial OrderPaymentDto ToOrderPaymentDto(this OrderPayment orderPayment);
    public static partial IQueryable<OrderPaymentDto> ToOrderPaymentDtoQueryable(this IQueryable<OrderPayment> orderPayment);
}