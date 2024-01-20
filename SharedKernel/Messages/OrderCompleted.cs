namespace SharedKernel.Messages
{
    using System;
    using System.Text;

    public interface IOrderCompleted
    {
        public Guid OrderId { get; set; }
    }

    public class OrderCompleted : IOrderCompleted
    {
        public Guid OrderId { get; set; }
    }
}