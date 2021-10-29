using System;

namespace CoreMicroservice.Model
{
    public class Transaction
    {
        public static readonly string DocumentName = "transaction";
        public Guid TransactionId { get; set; }
        public Guid AccountId { get; set; }
        public TransactionType TransactionType { get; set; }
        public OriginType OriginType { get; set; }
        public double Amount { get; set; }
    }
}
