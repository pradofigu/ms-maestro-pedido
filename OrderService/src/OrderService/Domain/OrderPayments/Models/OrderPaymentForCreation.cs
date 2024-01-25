namespace OrderService.Domain.OrderPayments.Models;

using Destructurama.Attributed;

public sealed record OrderPaymentForCreation
{
    public Guid OrderId { get; set; }
    public string PaymentStatus { get; set; }
    public string PaymentMethod { get; set; }
    public decimal AmountPaid { get; set; }
    public Guid TransactionId { get; set; }
}
