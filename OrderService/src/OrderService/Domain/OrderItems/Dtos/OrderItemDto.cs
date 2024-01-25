namespace OrderService.Domain.OrderItems.Dtos;

using Destructurama.Attributed;

public sealed record OrderItemDto
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
