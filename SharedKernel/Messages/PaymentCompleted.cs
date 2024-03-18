﻿using System;

namespace SharedKernel.Messages
{
    public interface IPaymentCompleted
    {
        public Guid PaymentId { get; set; }
        public Guid CorrelationId { get; set; }
        public string Status { get; set; }
    }

    public class PaymentCompleted : IPaymentCompleted
    {
        public Guid PaymentId { get; set; }
        public Guid CorrelationId { get; set; }
        public string Status { get; set; }
    }
}