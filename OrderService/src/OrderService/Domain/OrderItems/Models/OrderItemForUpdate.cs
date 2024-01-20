namespace OrderService.Domain.OrderItems.Models;

using Destructurama.Attributed;

public sealed record OrderItemForUpdate
{
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
