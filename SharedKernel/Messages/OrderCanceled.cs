namespace SharedKernel.Messages
{
    using System;
    using System.Text;

    public interface IOrderCanceled
    {
        public Guid OrderId { get; set; }
    }

    public class OrderCanceled : IOrderCanceled
    {
        public Guid OrderId { get; set; }
    }
}