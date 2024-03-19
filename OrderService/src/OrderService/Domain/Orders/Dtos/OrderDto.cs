

using System.Text.Json.Serialization;

namespace OrderService.Domain.Orders.Dtos;

using Destructurama.Attributed;

public sealed record OrderDto
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public int Number { get; set; }
    [JsonIgnore]
    public string Status { get; set; }
    public string CustomerNotes { get; set; }
    public string DiscountCode { get; set; }

}
