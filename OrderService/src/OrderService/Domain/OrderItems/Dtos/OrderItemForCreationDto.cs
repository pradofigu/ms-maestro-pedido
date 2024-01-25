namespace OrderService.Domain.OrderItems.Dtos;

using Destructurama.Attributed;

public sealed record OrderItemForCreationDto
{
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
