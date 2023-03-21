namespace FintechBankAPI.Entities
{
    public class Account:BaseEntity
    {       
        public string AccountNumber { get; set; } = null!;
        public double Balance { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; } = null!;
        public int CardId { get; set; }
        public virtual Card card { get; set; } = null!;
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
