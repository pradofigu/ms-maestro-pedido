namespace OrderService.Domain.Orders.Models;

using Destructurama.Attributed;

public sealed record OrderForUpdate
{
    public int Number { get; set; }
    public string Status { get; set; }
    public string CustomerNotes { get; set; }
    public string TotalAmount { get; set; }
    public string DiscountCode { get; set; }

}
