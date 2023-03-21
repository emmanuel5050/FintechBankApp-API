namespace FintechBankAPI.Entities
{
    public class Card:BaseEntity
    {
        public string CardNo { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
        public bool IsActive { get; set; }
        
    }
}
