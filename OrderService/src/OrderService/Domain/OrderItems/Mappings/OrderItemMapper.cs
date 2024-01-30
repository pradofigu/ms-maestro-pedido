namespace OrderService.Domain.OrderItems.Mappings;

using OrderService.Domain.OrderItems.Dtos;
using OrderService.Domain.OrderItems.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class OrderItemMapper
{
    public static partial OrderItemForCreation ToOrderItemForCreation(this OrderItemForCreationDto orderItemForCreationDto);
    public static partial OrderItemForUpdate ToOrderItemForUpdate(this OrderItemForUpdateDto orderItemForUpdateDto);
    public static partial OrderItemDto ToOrderItemDto(this OrderItem orderItem);
    public static partial IQueryable<OrderItemDto> ToOrderItemDtoQueryable(this IQueryable<OrderItem> orderItem);
}