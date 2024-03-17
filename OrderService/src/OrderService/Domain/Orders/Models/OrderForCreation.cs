using OrderService.Domain.OrderItems.Models;
using OrderService.Domain.OrderPayments.Models;

namespace OrderService.Domain.Orders.Models;

using Destructurama.Attributed;

public sealed record OrderForCreation
{
    public Guid? CorrelationId { get; set; }
    public int Number { get; set; }
    public string Status { get; set; }
    public string CustomerNotes { get; set; }
    public string DiscountCode { get; set; }
    public OrderPaymentForCreation OrderPayment { get; set; }
    public List<OrderItemForCreation> OrderItem { get; set; }

}
