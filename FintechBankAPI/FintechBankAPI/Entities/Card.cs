namespace FintechBankAPI.Entities
{
    public class Card:BaseEntity
    {
        public string CardNo { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }
        public bool IsActive { get; set; }
        
    }
}
