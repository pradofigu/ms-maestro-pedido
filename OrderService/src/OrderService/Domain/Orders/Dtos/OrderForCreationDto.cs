using OrderService.Domain.OrderItems.Dtos;
using OrderService.Domain.OrderPayments.Dtos;

namespace OrderService.Domain.Orders.Dtos;

using Destructurama.Attributed;

public sealed record OrderForCreationDto
{
    public Guid? CorrelationId { get; set; }
    public int Number { get; set; }
    public string Status { get; set; }
    public string CustomerNotes { get; set; }
    public string DiscountCode { get; set; }
    public OrderPaymentForCreationDto OrderPayment { get; set; }
    public List<OrderItemForCreationDto> OrderItem { get; set; }
}
