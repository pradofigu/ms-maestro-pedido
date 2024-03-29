
using System.Text.Json.Serialization;
using OrderService.Domain.OrderItems.Dtos;
using OrderService.Domain.OrderPayments.Dtos;

namespace OrderService.Domain.Orders.Dtos;

using Destructurama.Attributed;

public sealed record OrderForCreationDto
{
    [JsonIgnore]
    public Guid? CorrelationId { get; set; }
    [JsonIgnore]
    public int Number { get; set; }
    [JsonIgnore]
    public string Status { get; set; }
    public string CustomerNotes { get; set; }
    public string DiscountCode { get; set; }
    public OrderPaymentForCreationDto OrderPayment { get; set; }
    public List<OrderItemForCreationDto> OrderItem { get; set; }
}
