namespace OrderService.Domain.OrderPayments.Dtos;

using OrderService.Resources;

public sealed class OrderPaymentParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
