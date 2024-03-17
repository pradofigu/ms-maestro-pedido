namespace OrderService.Domain.Orders.Dtos;

using Destructurama.Attributed;

public sealed record OrderDto
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string Status { get; set; }
    public string CustomerNotes { get; set; }
    public string DiscountCode { get; set; }

}
