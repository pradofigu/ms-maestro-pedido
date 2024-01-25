namespace OrderService.Domain.Orders.Dtos;

using OrderService.Resources;

public sealed class OrderParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
