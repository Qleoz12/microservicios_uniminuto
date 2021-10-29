using System;

namespace CoreMicroservice.Model
{
    
    public class Account
    {
        public static readonly string DocumentName = "account";
        public Guid AccountId { get; set; }
        public AccountType AccountType { get; set; }
        public string CustomerId { get; set; }
        public string CardId { get; set; }
        public string BranchOffice { get; set; }
        public double Balance { get; set; }
    }
}
