namespace SharedKernel.Messages
{
    using System;

    public interface IOrderCompleted
    {
        public Guid CorrelationId { get; set; }
        public Guid OrderId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
        public string TotalAmount { get; set; }
        public string DiscountCode { get; set; }
    }

    public class OrderCompleted : IOrderCompleted
    {
        public Guid CorrelationId { get; set; }
        public Guid OrderId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
        public string TotalAmount { get; set; }
        public string DiscountCode { get; set; }
    }
}