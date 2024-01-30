namespace OrderService.Domain.OrderItems.Dtos;

using OrderService.Resources;

public sealed class OrderItemParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
