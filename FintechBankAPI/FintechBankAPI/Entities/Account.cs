namespace FintechBankAPI.Entities
{
    public class Account:BaseEntity
    {       
        public string AccountNumber { get; set; } = null!;
        public double Balance { get; set; }
        public string CurrencyId { get; set; }
        public virtual Currency Currency { get; set; } = null!;
        public virtual ICollection<Card> Cards { get; set; } = null!;
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
