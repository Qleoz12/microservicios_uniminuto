using System;

namespace CoreMicroservice.Model
{
    public class Card
    {
        public static readonly string DocumentName = "card";
        public Guid CardId { get; set; }
        public CardType CardType { get; set; }
        public bool IsActive { get; set; }
        public string PinCode { get; set; }
    }
}
