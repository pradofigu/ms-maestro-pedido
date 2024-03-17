namespace OrderService.Domain.OrderPayments.Models;

using Destructurama.Attributed;

public sealed record OrderPaymentForCreation
{
    public Guid OrderId { get; set; }
    public Guid TransactionId { get; set; }
    public string Status { get; set; }
    public string Method { get; set; }
    public decimal TotalAmount { get; set; }
    public string CardNumber { get; set; }
    public string CardToken { get; set; }
    public string CardHolderName { get; set; }
    public string ExpiryDate { get; set; }
    public string CVV { get; set; }
    public string Currency { get; set; }
}
